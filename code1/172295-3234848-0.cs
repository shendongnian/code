    public class A
    {
        public string Content { get; set; }
    
        public static implicit operator string(A obj)
        {
            return string.Concat("<span>", obj.Content, "</span>");
        }
    }
