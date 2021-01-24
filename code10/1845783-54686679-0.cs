    using (TextFieldParser parser = new TextFieldParser("csvFile"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        string url = string.Empty;
        while (!parser.EndOfData) 
        {
            string[] fields = parser.ReadFields();
            url = fields[0];
        }
    }
