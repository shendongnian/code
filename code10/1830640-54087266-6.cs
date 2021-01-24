    public class YourClass : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public GameObject sun;
        public float speed;
        private bool isRotating;
        // Handle pointer down
        public void OnPointerDown()
        {
            if(isRotating) return;
            
            StartCoroutine(RotateRoutine());
            isRotating = true;
            
        }
        // Handle pointer up
        public void OnPointerUp()
        {
            if(!isRotating) return;
            StopCoroutine(RotateRoutine());
            isRotating = false;
        }
        // Handle pointer exit
        public void OnPointerExit()
        {
            if(!isRotating) return;
            StopCoroutine(RotateRoutine());
            isRotating = false;
        }
        private IEnumerator RotateRoutine()
        {
            while(true)
            {
                transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
