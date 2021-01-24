    public class ControllerChangeReactor : MonoBehaviour {
     void Start()
     {
       KeyboardButton.OnValueChanged.AddListener(React); // add event listener
     }
     void React()  // will get called when keyboard is clicked
     {
        Debug.Log(KeyboardButton.controller); 
     }
    
    }
