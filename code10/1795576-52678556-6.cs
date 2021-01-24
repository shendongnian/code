    var counter = 0;
    var words = 0;,
    var previousIsWhiteSpace = false;
   
    while (counter < sentence.Length)
    {
        if (char.IsWhiteSpace(sentence[counter]))
        {
            previousIsWhiteSpace = true;
        }
        else if (previousIsWhiteSpace) 
        {
             words += 1;
             previousIsWhiteSpace = false;
        }
        counter += 1;
    }
