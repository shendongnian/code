    using UnityEngine;
    
    public class Control : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public bool isControl;
    
        public void ToControl()
        {
            if (!isControl && rigidbody)
            {
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
            }
        }
    }
    
