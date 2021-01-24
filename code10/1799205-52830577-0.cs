    static int[] returnLineFormat(string recordType)
    {
        int[] format = null;
    
        if ((recordType == "A"))
        {
            format = new int[] { 1, 11, 12 };
        }
        else if ((recordType == "B"))
        {
            format = new int[] { 1, 10, 12 };
        }
    
        return format;
    }
    
    static void Main(string[] args)
    {
        string[] data;
    
        using (TextFieldParser myReader = new TextFieldParser(@"TextParserExample.txt"))
        {
            myReader.TextFieldType = FieldType.FixedWidth;
    
            while (!myReader.EndOfData)
            {
                var recordType = myReader.PeekChars(1);
    
                if (!recordType.Equals("H"))
                {
                    var lineLength = myReader.PeekChars(1000).Length;
                    var currentLine = myReader.ReadLine();
                    var lengths = returnLineFormat(recordType);
                    lengths[2] = lineLength - (lengths[0] + lengths[1]);
    
                    myReader.FieldWidths = lengths;
                    myReader.HasFieldsEnclosedInQuotes = true;
                    data = myReader.ReadFields();
                }
    
            }
        }
    }
