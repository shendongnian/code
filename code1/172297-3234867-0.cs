    public class A
    {
        public string Content { get; set; }
        public static implicit operator string(A a)
        {
            return string.Format("<span>{0}</span>", a.Content);
        }
    }
