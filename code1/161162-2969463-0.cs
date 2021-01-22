    private string SpacedString(string myOldString)
    {
    
        System.Text.StringBuilder newStringBuilder = new System.Text.StringBuilder("");
        foreach(char c in myOldString.toCharArray())
        {
             newStringBuilder.Append(c + ' ');
        }
        
        string MyNewString = "";
        if(newStringBuilder.Length > 0)
        {
             // remember to trim off the last inserted space
             myNewString = newStringBuilder.ToString.Substring(0, NewStringBuilder.Length - 1);
        }
        // no else needed if the StringBuilder's length is <= 0... The resultant string would just be "", which is what it was intitialized to when declared.
        return myNewString;
    }
