    // 1. Iterate through the array with a foreach loop
    foreach (char character in charArray)
    {
        // Do stuff with the character
        char tempChar = character;
        if (character == 'a')
        {
            // Do stuff
        }
    }
    // 2. Iterate through the array with a for loop
    for (int i = 0; i < charArray.Length; i++)
    {
        char tempChar = charArray[i];
    }
    // 3. Get the character at a specific position (read: index) in the array
    char tempChat = charArray[0];
    
    // The string array works exactly the same for all three methods
    foreach (string singleString in stringArray)
    {
        // Do stuff with the string
        string tempString = singleString;
        if (tempString == "a")
        {
            // Do stuff
        }
    }
