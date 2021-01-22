    class Program
    {
        static void Main()
        {
            Foo foo = new Foo() { ProxyBar = "Blah" };
        }
    }
    
    class Foo : IFoo
    {
        string IFoo.Bar { get; set; }
    
        public string ProxyBar
        {
            set { (this as IFoo).Bar = value; }
        }
    }
    
    interface IFoo
    {
        string Bar { get; set; }
    }
