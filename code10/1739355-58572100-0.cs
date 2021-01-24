    using UnityEngine;
    using UnityEngine.Events;
    
    public class TriggerKey : MonoBehaviour
    {
    
        [Header("----Add key to trigger on pressed----")]
        public string key;
    
        // Unity event inspector
        public UnityEvent OnTriggerKey;
    
        public void OnGUI()
        {    // triiger event on trigger key
            if (Event.current.Equals(Event.KeyboardEvent(key)))
            {
                OnTriggerKey.Invoke();
                print("test trigger btn");
            }
    
        }
    }
