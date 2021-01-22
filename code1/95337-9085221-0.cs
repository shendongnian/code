    // Using attributes:
    public class MyCustomObject
    {
        [CsvField( Name = "First Name" )]
        public string StringProperty { get; set; }
    
        [CsvField( Index = 0 )]
        public int IntProperty { get; set; }
        [CsvField( Ignore = true )]
        public string ShouldIgnore { get; set; }
    }
