    // Reference those in the inspector
    public InputField Textfield1;
    public InputField Textfield2;
    
    public void DevideByTen()
    {
        float num1;
        float.TryParse(Textfield1.text, num1);
    
        var devided = num1 / 10.0f;
    
        // I didn't understand whether you want the original value num1
        Textfield2.text = num1.ToString();  
        // or whether you want the result of the deviding
        Textfield2.text = devided.ToString();
    }
