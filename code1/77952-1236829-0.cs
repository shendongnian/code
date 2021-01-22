    static void Main(string[] args)
    {
        while (true)
        {
            if (Clipboard.ContainsText())
            {
                string s = Clipboard.GetText();
    
                Console.WriteLine(s);
    
                Clipboard.Clear();
            }
        }
    }
