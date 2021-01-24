    private string GetText(string s)
    {
        string textToReturn = "Hello";
        using (StreamReader sr = new StreamReader(File.OpenRead(s)))
        {
            textToReturn = sr.ReadToEnd();
        }
        return textToReturn;
    }
