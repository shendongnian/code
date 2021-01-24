    using UnityEngine;
    
    public class KeepRotation : MonoBehaviour {
    
        Quaternion rotation;
        void Awake()
        {
            rotation = transform.rotation;
        }
        void LateUpdate()
        {
            transform.rotation = rotation;
        }
    }
