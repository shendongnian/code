    class Image
    {
            
                public int ID { get; set; }
                public int? ProductId {get; set; } // by making the Id nullable, the FK is optional
                public Product Product { get; set;}
                public int? CategoryId { get; set;}
                public Category Category { get; set;}
                public string FileName { get; set; }
                public int Length { get; set; }
                public byte[] Data { get; set; }     // image binary data
    
    }
