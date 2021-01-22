    public class Foo<T>
    {
        public Foo(T val)
        {
            this.Value = val.ToString();
        }
        public Foo(string val)
        {
            this.Value = "--" + val + "--";
        }
        public string Value { get; set; }
    }
