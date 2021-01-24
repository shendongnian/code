    public class TextMeshAdd : MonoBehaviour 
    {
    	//input field object
        public TMP_InputField tmpInputField;
    
    	// Use this for initialization
    	void Start () 
        {
            //Add a listener function here
            //Note: The function has to be of the type with parameter string
    		tmpInputField.onEndEdit.AddListener(TextMeshUpdated);
    	}
    
    	public void TextMeshUpdated(string text) 
        {
    		Debug.Log("Output string "  + text);
    	}
    }
