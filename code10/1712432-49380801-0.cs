    public class KeyboardButton : MonoBehaviour {
        public UnityEvent OnValueChanged;
        public static int controller;
    
        public void buttonClick () {
            controller = 1;
            OnValueChanged.Invoke();
        }
    }
