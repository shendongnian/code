    using (StreamReader sr = new StreamReader("XmlFile.xml"))
    {
        string line = sr.ReadLine();
        int closeQuoteIndex = line.LastIndexOf("\"") - 1;
        int openingQuoteIndex = line.LastIndexOf("\"", closeQuoteIndex);
        string encoding = line.Substring(openingQuoteIndex + 1, closeQuoteIndex - openingQuoteIndex);
    }
