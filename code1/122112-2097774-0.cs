    public class foo
    {
        public string Test { get { return "foo"; } } 
    }
    public class bar : foo
    {
        public new string Test { get { return "bar"; } }
    }
