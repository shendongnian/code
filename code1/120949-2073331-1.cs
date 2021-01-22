    public interface ISomeInterface
    {
        bool SomeBool { set; }
    }
    class SomeBase : ISomeInterface
    {
        public virtual bool SomeBool { get; set; }
    }
    class SomeDerived : SomeBase
    {
        // ... extends SomeBase
    }
    static class Program
    {
        static void Main()
        {
            var item1 = new SomeBase();
            var item2 = new SomeDerived();
            var items = new List<ISomeInterface> { item1, item2};
            ISomeInterface group = GroupGenerator.Create(items);
            group.SomeBool = true;
            Console.WriteLine(item1.SomeBool); // true
            Console.WriteLine(item2.SomeBool); // true
            group.SomeBool = false;
            Console.WriteLine(item1.SomeBool); // false
            Console.WriteLine(item2.SomeBool); // false
        }
    }
