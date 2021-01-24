    public class YourClass : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public GameObject sun;
        public float speed;
        private bool isRotating;
        private void Update()
        {
            if(!isRotating) return;
            transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
        }
        // Handle pointer down
        public void OnPointerDown()
        {
            isRotating = true;
        }
        // Handle pointer up
        public void OnPointerUp()
        {
            isRotating = false;
        }
        // Handle pointer exit
        public void OnPointerExit()
        {
            isRotating = false;
        }
    }
