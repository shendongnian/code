    using Microsoft.VisualBasic.FileIO;
    string csv = "1,2,3,"4,3","a,"b",c",end";
    TextFieldParser parser = new TextFieldParser(new StringReader(csv));
    //To read from file
    //TextFieldParser parser = new TextFieldParser("csvfile.csv");
    parser.HasFieldsEnclosedInQuotes = true;
    parser.SetDelimiters(",");
    string[] fields =null;
    while (!parser.EndOfData)
    {
        fields = parser.ReadFields();
    }
    parser.Close();
