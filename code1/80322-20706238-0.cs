    static string NormalizeWithLoop(string input)
    {
        StringBuilder output = new StringBuilder(input.Length);
    
        char lastChar = '*';  // anything other then space 
        for (int i = 0; i < input.Length; i++)
        {
            char thisChar = input[i];
            if (!(lastChar == ' ' && thisChar == ' '))
                output.Append(thisChar);
    
            lastChar = thisChar;
        }
    
        return output.ToString();
    }
