    using UnityEngine;
    
    [ExecuteInEditoMode]
    public class Control : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public bool isControl;
    
        // repeatedly check the bool
        private void LateUpdate()
        {
            ToControl();
        }
    
        public void ToControl()
        {
            if (!isControl && rigidbody)
            {
                // in editmode use DestroyImmediate
                if (Application.isEditor && !Application.isPlaying)
                {
                    DestroyImmediate(rigidbody);
                }
                else
                {
                    Destroy(rigidbody);
                }
    
                rigidbody = null;
            }
            else if(isControl && !rigidbody)
            {
                rigidbody = gameObject.AddComponent<Rigidbody>();
 
                // adjust settings of rigidbody
            }
        }
    }
