    public class YourClass : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public GameObject sun;
        public float speed;
        private bool isRotating;
        // Handle pointer down
        public void OnPointerDown()
        {
            // skip if already rotating
            if(isRotating) return;
            
            StartCoroutine(RotateRoutine());
            isRotating = true;
            
        }
        // Handle pointer up
        public void OnPointerUp()
        {
            // skip if not rotating
            if(!isRotating) return;
            StopCoroutine(RotateRoutine());
            isRotating = false;
        }
        // Handle pointer exit
        public void OnPointerExit()
        {
            // skip if not rotating
            if(!isRotating) return;
            StopCoroutine(RotateRoutine());
            isRotating = false;
        }
        private IEnumerator RotateRoutine()
        {
            // whuut?!
            // Don't worry coroutines work a bit different
            // the yield return handles that .. never forget it though ;)
            while(true)
            {
                // rotate a bit
                transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
 
                // leave here, render the frame and continue in the next frame
                yield return null;
            }
        }
    }
