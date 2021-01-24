    [RequireComponent(typeof(Button))]
    public class KeyboardButton : MonoBehaviour
    {
        // Which key should this Button react to?
        // Select this in the inspector for each Button
        public KeyCode _reactToKey;
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        // Wait for the defined key
        private void Update()
        {
            // If key not pressed do nothing
            if(!Input.GetKeyDown(_reactToKey)) return;
         
            // This simply tells the button to execute it's onClick event
            // It is exactly the same as if you would have clicked it in the UI.
            _button.onClick.Invoke();       
        }
    }
