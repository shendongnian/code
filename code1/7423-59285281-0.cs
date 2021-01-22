    internal class Parent
    {
        public Parent()
        {
            Console.WriteLine("Parent ctor");
            Console.WriteLine(Something);
        }
        protected virtual string Something { get; } = "Parent";
    }
    internal class Child : Parent
    {
        public Child()
        {
            Console.WriteLine("Child ctor");
            Console.WriteLine(Something);
        }
        protected override string Something { get; } = "Child";
    }
