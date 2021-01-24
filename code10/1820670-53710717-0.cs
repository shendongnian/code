    using UnityEngine;
    
    public class GoToTouch : MonoBehaviour
    {
        public Camera cam;//put your main camera here
        public float speed;//Speed of movement
        Vector3 LastTouch;
        void Start()
        {
            LastTouch = Vector3.zero;
        }
    
        void Update()
        {
            //We check for new touches etch frame
            if (Input.touchCount> 0)
                LastTouch = Input.touches[0].rawPosition;
            //We move towards the last touch
            if(LastTouch != Vector3.zero)transform.position=
        Vector3.Lerp(transform.position,cam.ScreenToWorldPoint(LastTouch),speed*Time.DeltaTime);
        }
    }
