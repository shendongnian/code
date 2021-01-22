    public static string[][] ReadSV(string filepath, char separator)
    {
        var reader = new Microsoft.VisualBasic.FileIO.TextFieldParser(filepath);
        reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
        reader.SetDelimiters(separator.ToString());
        var res = new List<string[]>();
        while (!reader.EndOfData)
            res.Add(reader.ReadFields());
        return res.ToArray();
    }
