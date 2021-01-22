    public abstract class IteratorExtender {
        public int ListIndex { get; set; }
        public bool IsFirst { get; set; } 
        public bool IsLast { get; set; } 
    }
    public class Item : IteratorExtender {}
