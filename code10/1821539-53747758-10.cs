    using UnityEngine;
    using UnityEngine.Events;
    
    public class KeyboardButton : MonoBehaviour
    {
        // Which key should this Button react to?
        // Select this in the inspector for each Button
        public KeyCode ReactToKey;
    
        // reference the target methods here just as 
        // you would do with the Button's onClick
        public UnityEvent OnPress;
    
        // Wait for the defined key
        private void Update()
        {
            // If key not pressed do nothing
            if (!Input.GetKeyDown(ReactToKey)) return;
    
            OnPress.Invoke();
        }
    }
