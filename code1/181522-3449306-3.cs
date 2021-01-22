    public static string DecodeEmail(string contents)
    {
        string[] delimiter = new string[] { "Status:" };
        string base64string = contents.Split(delimiter, StringSplitOptions.None)[1];
        return DecodeBase64(base64string);
    }
