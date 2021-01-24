    // Reference those in the inspector
    public InputField Textfield1;
    public InputField Textfield2;
    
    public void DevideByTen()
    {
        float num1;
        // Try to convert the inserted string into a float value
        // if wrong input or bad format this returns 0 instead of throwing an exception
        float.TryParse(Textfield1.text, num1);
        // of you prefer to explicitly throw an exception instead you could do
        try
        {
            num1 = float.Parse(Textfield1.text);
        }
            catch(Exception e)
        {
            Debug.LogWarningFormat(this, "Could not parse input: /"{0}/"", Textfield1.text);
            Debug.LogException(e);
            return;
        }
    
        // Devide by 10
        var devided = num1 / 10.0f;
    
        // I didn't understand whether you want the original value num1
        Textfield2.text = num1.ToString();  
        // or whether you want the result of the deviding
        Textfield2.text = devided.ToString();
        // Did you also want to write back the decided value to the Textfield1?
        Textfield1.text = decided.ToString();
    }
