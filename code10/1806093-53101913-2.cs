    using UnityEngine;
    
    public class Example : MonoBehaviour
    {
        // Interpolates rotation between the rotations
        // of from and to.
        // (Choose from and to not to be the same as
        // the object you attach this script to)
    
        Transform from;
        Transform to;
        float speed = 0.1f;
        void Update()
        {
            transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
        }
    }
