    short? shiftTime = null;
    string userInput = shiftTimeInput.Text;
    if (userInput.Length > 0) // User has put *something* in
    {
        short value;
        if (short.TryParse(userInput, out value))
        {
            shiftTime = value;
        }
        else
        {
            // Do whatever you need to in order to handle invalid
            // input.
        }
    }
    // Now shiftTime is either null if the user left it blank, or the right value
    // Call the Update method passing in shiftTime.
