    public void OnStoppedEditing(string text) {
      if (text == "") { //if the text in the InputField is empty, run the following code
        errorWindow.SetActive(true); //sets the errorWindow active, so you can see it
        errorText.text = "This field cannot be blank"; //sets the text of the errorText
      }
        
    }
    public void Start() {
       myField.onEndEdit.AddListener(delegate {OnStoppedEditing(mainInputField); }); //adds a listener that runs OnStoppedEditing when you stop editing myField
       myField = gameObject.getComponent<InputField>(); // sets myField to the InputField component attached to this object
       errorText = errorWindow.getComponent<Text>(); // sets errorText to the Text component attached to errorWindow
    }
    public GameObject errorWindow; // the error window attached to this GameObject
    Text errorText; // the text component on the errorWindow
    InputField myField; // the InputField that we want to detect changes to
