    [DelimitedRecord(",")]
    public class MyRecord
    { 
     public string field1;
     [FieldQuoted('"', QuoteMode.OptionalForRead, MultilineMode.AllowForRead)]
     public string field2;
    }
