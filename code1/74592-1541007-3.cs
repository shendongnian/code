    public static IEnumerable<string[]> ReadSV(TextReader reader, params string[] separators)
    {
        var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(reader);
        parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
        parser.SetDelimiters(separators);
        while (!parser.EndOfData)
            yield return parser.ReadFields();
    }
