    public class YourClass : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public GameObject sun;
        public float speed;
        private bool isRotating;
        private void Update()
        {
            // if not rotating do nothing
            if(!isRotating) return;
            // rotate a bit
            transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
        }
        // Handle pointer down
        public void OnPointerDown()
        {
            // enable rotating
            isRotating = true;
        }
        // Handle pointer up
        public void OnPointerUp()
        {
            // disable rotating
            isRotating = false;
        }
        // Handle pointer exit
        public void OnPointerExit()
        {
            // disable rotating
            isRotating = false;
        }
    }
