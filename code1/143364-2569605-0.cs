    string textBoxText = "12kj3";
    
    if (!textBoxText.Equals(String.Empty))  // this forces user to enter something
    {
        foreach (char c in textBoxText.ToArray())
        {
            if (!Char.IsDigit(c))
            {
                //return false;
            }
        }
    
        //return true;
    }
    else
    {
        Console.WriteLine("Cannot be empty!");
    }
