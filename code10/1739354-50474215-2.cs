    public class test : MonoBehaviour, IKeyboardEvent
    {
        public void OnKey(KeyCode keycode)
        {
            Debug.Log("Key held down: " + keycode);
        }
    
        public void OnKeyDown(KeyCode keycode)
        {
            Debug.Log("Key pressed: " + keycode);
        }
    
        public void OnKeyUP(KeyCode keycode)
        {
            Debug.Log("Key released: " + keycode);
        }
    }
