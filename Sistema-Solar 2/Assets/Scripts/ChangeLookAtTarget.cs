using UnityEngine;

public class ChangeLookAtTarget : MonoBehaviour {

    public GameObject target; // the target that the camera should look at
    private static AudioSource currentAudioSource;

    void Start() {
        if (target == null) 
        {
            target = this.gameObject;
            Debug.Log("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
        }
    }

    // Called when MouseDown on this gameObject
    void OnMouseDown () {
        // change the target of the LookAtTarget script to be this gameobject.
        LookAtTarget.target = target;
        Camera.main.fieldOfView = 60 * target.transform.localScale.x;

        if (currentAudioSource != null && currentAudioSource.isPlaying) {
            currentAudioSource.enabled = false;
        }
        
        AudioSource newAudioSource = target.GetComponent<AudioSource>();

        if (newAudioSource != null) {
            newAudioSource.enabled = true;
            currentAudioSource = newAudioSource; 
        }
    }
}