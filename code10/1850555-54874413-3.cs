    string s = inputTextBox.Text;
    string[] parts = s.Split(' ');
    string lastword = parts[parts.Length - 1];
    
    for (int i = 0; i < parts.Length - 1; i++)
    {
        if (parts[i] != lastword)
        {
            // do something                  
        }
    }
    
