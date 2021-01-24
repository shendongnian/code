    class Program
    {
        public class ParentClass
        {
            public ParentClass()
            {
                Console.WriteLine("ChildClass drived from me ");
            }
        }
        public class ChildClass : ParentClass
        {
            public ChildClass() : base() // base() call is voluntary
            {
                Console.WriteLine("This also use my Ctor");
            }
        }
        public static void Main()
        {
            ChildClass child = new ChildClass();
        }
    }
