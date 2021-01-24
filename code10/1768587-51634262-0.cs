    private void SubmitInput(string arg0)
    {
    
        string currentText = output.text;
        string newtext = currentText + "\n" + arg0;
    
        string binaryText; //This string will contain the Binary Data
    
        foreach (char c in newtext)
            {
            binaryText += (Convert.ToString(c, 2).PadLeft(8, '0')); //Add that character's binary data to the binary string
            }
    
        output.text = newtext + " in binary is " + "\n" + binaryText;//Print the binary string after the speicifed text
    
        textInput.text = "";
    
        textInput.ActivateInputField();
    
    }
