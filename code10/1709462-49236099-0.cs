    using UnityEngine;
    using System.Collections;
    public class ExampleClass : MonoBehaviour
    {
        public Transform target;
        void Update() {
            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;
        }
    }
