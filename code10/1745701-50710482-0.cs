    public void Main()
    {
        List<LineOfText> lines = ReadTextFile("file.txt");
        
        // Use resulting list like this
        if (lines.Count > 0)
        {
            foreach (var line in lines)
            {
                Console.WriteLine($"[{line.LineNumber}] {line.FirstLinePiece}\t{line.UntranslatedText}");
            }
        }
    }
    
    class LineOfText
    {
        public int LineNumber { get; set; }
        public string FirstLinePiece { get; set; }
        public string UntranslatedText { get; set; }
        public string TranslatedText { get; set; }
    }
    private List<LineOfText> ReadTextFile(string filePath)
    {
        List<LineOfText> array = new List<LineOfText>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            // Read entire file and split into lines by new line or carriage return symbol
            string[] lines = sr.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            // Parse each line and add to the list
            for (int i = 0; i < lines.Length; i++)
            {
                int tabIndex = lines[i].IndexOf('\t');
                string firstPiece = lines[i].Substring(0, tabIndex);
                string restOfLine = lines[i].Substring(tabIndex + 1);
                array.Add(new LineOfText()
                {
                    LineNumber = i,
                    FirstLinePiece = firstPiece,
                    UntranslatedText = restOfLine
                });
            }
        }
        return array;
    }
