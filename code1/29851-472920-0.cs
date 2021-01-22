    // C# to convert a string to a byte array.
    public static byte[] StrToByteArray(string str)
    {
        System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
        return encoding.GetBytes(str);
    }
    
    
    // C# to convert a byte array to a string.
    byte [] dBytes = ...
    string str;
    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
    str = enc.GetString(dBytes);
