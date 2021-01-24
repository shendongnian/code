    public class HoldableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public UnityEvent whilePressed;       
        private bool isPressed;
        // Handle pointer down
        public void OnPointerDown()
        {
            // skip if already rotating
            if(isPressed) return;
            
            StartCoroutine(PressedRoutine());
            isPressed= true;
            
        }
        // Handle pointer up
        public void OnPointerUp()
        {
            // skip if not rotating
            if(!isPressed) return;
            StopCoroutine(PressedRoutine());
            isPressed= false;
        }
        // Handle pointer exit
        public void OnPointerExit()
        {
            // skip if not rotating
            if(!isPressed) return;
            StopCoroutine(PressedRoutine());
            isPressed= false;
        }
        private IEnumerator RotateRoutine()
        {
            // whuut?!
            // Don't worry coroutines work a bit different
            // the yield return handles that .. never forget it though ;)
            while(true)
            {
                // call whatever is referenced in whilePressed;
                whilePressed.Invoke();
 
                // leave here, render the frame and continue in the next frame
                yield return null;
            }
        }
    }
