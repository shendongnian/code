    [MetadataType(typeof(TestMetaData))] 
    public class Test 
    { 
        public string Prop { get; set; } 
     
        public class TestMetaData 
        { 
            [Required] 
            public string Prop { get; set; } 
        } 
    }
