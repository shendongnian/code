    [DelimitedRecord(",")]
    public class Foo
    {
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime TheDate { get; set; }
        public int TheFirstInt { get; set; }
        public int TheSecondInt { get; set; }
        public string TheString { get; set; }
    }
