    public class SwipeControl : MonoBehaviour {
    
        public Transform myCylinder;
    
        void Update()
        {
            if (Input.touchCount == 1)
            {
                // GET TOUCH 0
                Touch touch0 = Input.GetTouch(0);
    
                // APPLY ROTATION
                if (touch0.phase == TouchPhase.Moved)
                {
                    myCylinder.transform.Rotate(0f, 0f, touch0.deltaPosition.x);
                }
    
            }
        }
    }
