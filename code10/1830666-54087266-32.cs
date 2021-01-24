    public class HoldableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public UnityEvent whilePressed;
        private bool isPressed;
        private void Update()
        {
            // if not rotating do nothing
            if(!isPressed) return;
            // call whatever is referenced in whilePressed;
            whilePressed.Invoke();
        }
        // Handle pointer down
        public void OnPointerDown()
        {
            // enable pressed
            isPressed= true;
        }
        // Handle pointer up
        public void OnPointerUp()
        {
            // disable pressed
            isPressed= false;
        }
        // Handle pointer exit
        public void OnPointerExit()
        {
            // disable pressed
            isPressed= false;
        }
    }
