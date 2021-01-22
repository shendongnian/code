    var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(file);
    parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
    //comma delimiter for CSV
    parser.SetDelimiters(new string[] { "," });
    
    while (!parser.EndOfData)
    {
        string[] row = parser.ReadFields();
        /* do something */
    }
