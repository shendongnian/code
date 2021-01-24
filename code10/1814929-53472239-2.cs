    abstract class A
    {
        public string Name { get; set; }
        public abstract WriteLine();
    }
    class B : A
    {
        public string Name { get; set; }
        public override WriteLine()
        {
                Console.WriteLine($"B = {Name}");
        }
    }
    class C : A
    {
        public string Name { get; set; }
        public override WriteLine()
        {
                Console.WriteLine($"C = {Name}");
        }
    }
