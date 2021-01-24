    using UnityEngine;
    
    // make sure you are not accidentely using 
    // UnityEngine.Experimental.UIElements.Button
    using UnityEngine.UI;
    
    [RequireComponent(typeof(Button))]
    public class KeyboardButton : MonoBehaviour
    {
        // Which key should this Button react to?
        // Select this in the inspector for each Button
        public KeyCode ReactToKey;
        private Button _button;
    
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
    
        // Wait for the defined key
        private void Update()
        {
            // If key not pressed do nothing
            if (!Input.GetKeyDown(ReactToKey)) return;
    
            // This simply tells the button to execute it's onClick event
            // So it does exactly the same as if you would have clicked it in the UI
            _button.onClick.Invoke();
        }
    }
