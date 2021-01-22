    public enum MyEnum
    {
        Bar,
        Foo
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var containsFoo = Enum.GetNames(typeof(MyEnum)).Any(x => x.ToLower() == "foo");
            Console.WriteLine(containsFoo);
        }
    }
