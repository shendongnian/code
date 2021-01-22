    public class MyClass : System.Collections.Specialized.StringCollection
    {
        public override string ToString()
        {
            var c = new string[this.Count];
            this.CopyTo(c,0);
            return string.Join(",", c);
        }
    }
