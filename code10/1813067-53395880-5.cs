    class Program
    {
        public class ParentClass
        {
            public ParentClass(string foo)
            {
                Console.WriteLine("ChildClass drived from me ");
            }
        }
        public class ChildClass : ParentClass
        {
            public ChildClass() : base("some foo") // base call is obligatory
            {
                Console.WriteLine("This also use my Ctor");
            }
        }
        public static void Main()
        {
            ChildClass child = new ChildClass();
        }
    }
