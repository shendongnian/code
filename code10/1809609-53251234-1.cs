    [DelimitedRecord(",")]
    class Person
    {
        [FieldQuoted]
        public string Name { get; set; }
        [FieldConverter(ConverterKind.Int32)]
        public int Age { get; set; }
        public string State { get; set; }
    }
