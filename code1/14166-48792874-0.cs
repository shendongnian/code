    static void ReverseString(string text)
    {
        string sub = "";
        int indexCount = text.Length - 1;
        for (int i = indexCount; i > -1; i--)
        {
            sub = text.Substring(i, 1);
            Console.Write(sub);
        }
    }
