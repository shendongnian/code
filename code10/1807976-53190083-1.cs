    public class B
    {
        public static explicit operator B(string source)
        {
            return new B(){Field2 = source};
        }
        
        public string Field2 { get; set; }
    }
