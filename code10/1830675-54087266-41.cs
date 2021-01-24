    [RequireComponent(typeof(Button))]
    public class HoldableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public UnityEvent whilePressed;
        private bool isPressed;
        private Button button;
        private void Awake()
        {
            button = GetComponent<Button>();
            
            if(!button)
            {
                Debug.LogError("Oh no no Button component on this object :O",this);
            }
        }
        private void Update()
        {
            // if button is not interactable do nothing
            if(!button.enabled || !button.interactable) return;
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
