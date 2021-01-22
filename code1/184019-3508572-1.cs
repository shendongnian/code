    TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv");
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters(",");
    while (!parser.EndOfData) 
    {
        //Processing row
        string[] fields = parser.ReadFields();
        foreach (string field in fields) 
        {
            //TODO: Process field
        }
    }
    parser.Close();
