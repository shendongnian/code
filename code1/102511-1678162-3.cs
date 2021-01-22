    static void Main(string[] args)
    {
        const Int32 MAX_WIDTH = 60;
        int offset = 0;
        string text = Regex.Replace(File.ReadAllText("oneline.txt"), @"\s{2,}", " ");
        List<string> lines = new List<string>();
        while (offset < text.Length)
        {
            int index = text.LastIndexOf(" ", 
                             Math.Min(text.Length, offset + MAX_WIDTH));
            string line = text.Substring(offset,
                (index - offset <= 0 ? text.Length : index) - offset );
            offset += line.Length + 1;
            lines.Add(line);
        }
    }
