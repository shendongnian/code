    var changeFromCode = false;
    void abc()
    {
       // This is where you change value in code.
       changeFromCode = true;
       ud1.Value = 15;
       changeFromCode = false;
    }
    // Sorry, I am not sure about handler signatures
    void UpDownValueChanged(object sender, EventArgs e)
    {
       if (changeFromCode)
           return;
    }
