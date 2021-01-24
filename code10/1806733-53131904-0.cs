    public class Book
    {
        public int BookId{ get; set; }
    
        public string Title{ get; set; }
    
        [ScriptIgnore]
        public virtual Author Author{ get; set; } 
    }
