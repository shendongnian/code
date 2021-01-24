    bool hasPrinted = false;
    
    if (!hasPrinted && textbox1.Text.Contains("hello world"))
    {  
        hasPrinted = true;
        System.Diagnostics.Debug.WriteLine("Hi");
    }
