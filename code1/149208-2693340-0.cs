    static private Dictionary<int, string> errorMessages;
    static
    {
        // create and fill the Dictionary
    }
    // meanwhile, elsewhere in the code...
    if (result is not ok) {
        throw new ClientException(string.Format(errorMessages[result], cTbx.Text, dTbx.Text));
    }
