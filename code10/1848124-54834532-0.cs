    public class ClampMovementController : MonoBehaviour
    {
        public float currentPos;
        public GameObject capsule;
    
        void Update()
        {
            //store the value of object localPosition
            Vector3 pos = capsule.transform.localPosition;
            //modification on the value
            pos.y = Mathf.Clamp(pos.y, currentPos, currentPos);
            //rerassign the new value to the object localPosition
            capsule.transform.localPosition = pos;
        }
    
    }
