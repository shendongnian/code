    using UnityEngine.UI;
    using UnityEngine;
    [RequireComponent(typeof(InputField))]
    public class InputFieldListener : MonoBehaviour
    {
    
        void Start()
        {
        GetComponent<InputField>().onEndEdit.AddListener(OnEndEdit);
    
        }
        void OnEndEdit(string s)
        {
            Debug.Log("user entered: "+s);
        }
    }
