    //Turn a string into a byte[], for your PC app to send
    byte[] byteData = System.Text.Encoding.ASCII.GetBytes("Message");
    //On the other end read that byte[] into ASCII characters
    char[] charsData = System.Text.Encoding.ASCII.GetChars(byteData);
    //Check you read something, and turn those chars into a string.
    if (charsData != null && charsData.Length > 0)
        string stringData = new string(chars);
