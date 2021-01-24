    public class SomeClass
    {
        [Key]
        public long Id { get; set; }
    
        [SearchTypeAttribute(
            SType = typeof(Enums.myEnum),
            SItems =  new[] { Enums.FirstOpt, Enums.SecondOpt, ...}
        )]
        public string Type{ get; set; } 
    
     }
