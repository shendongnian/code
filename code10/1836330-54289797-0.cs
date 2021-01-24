    public void OnValueChanged(string input) 
    {
       
        if (input.Length == 2)
        {
            InputField.text = input+":";
            InputField.caretPosition = 3;
        }
        
    }
