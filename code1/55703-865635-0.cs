    // C# to convert a byte array to a string.
    byte [] dBytes = ...
    string str;
    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
    str = enc.GetString(dBytes);
