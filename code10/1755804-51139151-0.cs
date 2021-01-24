     public class A
        {
            public int Id { get; set; }
    
            public int B1Id { get; set; }
            public int B2Id { get; set; }
            public int B3Id { get; set; }
    
            [ForeignKey("B1Id")]
            public B B1 { get; set; }
    
            [ForeignKey("B2Id")]
            public B B2 { get; set; }
    
            [ForeignKey("B3Id")]
            public B B3 { get; set; }
        }
    
        public class B
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
        }
