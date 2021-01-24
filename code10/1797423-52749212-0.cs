     [Table("MySchema.Content")]
        public class Content
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Text { get; set; }
            public ICollection<State> States { get; set; }
        }
    
        [Table("dbo.State")]
        public class State
        {
            public int Id { get; set; } 
            public string Name { get; set; }
            public string ShortName { get; set; }
            public Content Content { get; set; }  //add new Map Object
            public int ContentId { get; set; }  //for query performans
        }
