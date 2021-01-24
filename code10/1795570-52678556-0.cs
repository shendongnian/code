    int counter = 0;
    int words = 0;,
    bool previousIsWhiteSpace = false;
   
    while (counter < sentence.Length)
    {
        if (char.IsWhiteSpace(sentence[counter])
        {
            previousIsWhiteSpace = true;
        }
        else (previousIsWhiteSpace) 
        {
             words += 1;
             previousIsWhiteSpace = false;
        }
        counter += 1;
    }
