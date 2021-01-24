     public class Test
    {
            [Key]
            [MaxLength(30)]
            public string Id { get; set; }
    
            public string Name { get; set; }
    
            [DataType(DataType.Currency)]
            [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
            public float? Cost { get; set; }
    
    
    }
