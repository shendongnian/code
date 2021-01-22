    private string ReadText(TextReader reader)
    {
        string text;
        string line = reader.ReadLine();
        text = line.Substring(1); // Strip first quotation mark.
        while (!text.EndsWith("\"")) {
            line = reader.ReadLine();
            text += line;
        }
        return text.Substring(0, text.Length - 1); // Strip last quotation mark.
    }
