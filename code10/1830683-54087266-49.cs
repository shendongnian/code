    [RequireComponent(typeof(Button))]
    public class HoldableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        // reference the same way as in onClick
        public UnityEvent whilePressed;       
        private Button button;
        private bool isPressed;
        private void Awake()
        {
            button = GetComponent<Button>();
            
            if(!button)
            {
                Debug.LogError("Oh no no Button component on this object :O",this);
            }
        }
        // Handle pointer down
        public void OnPointerDown()
        {
            // skip if the button is not interactable
            if(!button.enabled || !button.interactable) return;
            // skip if already rotating
            if(isPressed) return;
            
            StartCoroutine(PressedRoutine());
            isPressed= true;
            
        }
        // Handle pointer up
        public void OnPointerUp()
        {
            isPressed= false;
        }
        // Handle pointer exit
        public void OnPointerExit()
        {
            isPressed= false;
        }
        private IEnumerator RotateRoutine()
        {
            // repeatedly call whilePressed until button isPressed turns false
            while(isPressed)
            {
                // break the routine if button was disabled meanwhile
                if(!button.enabled || !button.interactable)
                {
                    isPressed = false;
                    yield break;
                }
                // call whatever is referenced in whilePressed;
                whilePressed.Invoke();
 
                // leave here, render the frame and continue in the next frame
                yield return null;
            }
        }
    }
