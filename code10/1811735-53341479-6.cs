    using UnityEngine;
    
    public class Example : MonoBehaviour
    {
        void Update()
        {
            // Spin the object around the world origin at 20 degrees/second.
            transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        }
    }
