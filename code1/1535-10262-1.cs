    string filename = @textBox1.Text;
    string[] fields;
    string[] delimiter = new string[] {"|"};
    using (Microsoft.VisualBasic.FileIO.TextFieldParser parser =
           new Microsoft.VisualBasic.FileIO.TextFieldParser(filename)) {
        parser.Delimiters = delimiter;
        parser.HasFieldsEnclosedInQuotes = false;
        
        while (!parser.EndOfData) {
            fields = parser.ReadFields();
            //Do what you need
        }
    }
