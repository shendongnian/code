     public class KeyboardButton : MonoBehaviour {
            public static UnityEvent OnValueChanged;
            public static int controller;
        
            public void buttonClick () {
                controller = 1;
                OnValueChanged.Invoke();
            }
        }
