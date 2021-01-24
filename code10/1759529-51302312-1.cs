    public class Initializer : MonoBehaviour
    {
       public Text Textbox;
       public Button Button1;
       public Button Button2;
    
     // Awake is called before Start, so Start() in your Composite script will be called 
     // after these fields have been initialized
       void Awake() 
       {
          Level.Textbox = this.Textbox;
          Level.Button1 = this.Button1;
          Level.Button2 = this.Button2;
       }
    }
