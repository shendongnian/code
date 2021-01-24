    class Program
    {
    
        public class ParentClass
        {
            public ParentClass()
            {
                Console.WriteLine("ParentClass constructor is called");
            }
    
        }
    
        public class ChildClass : ParentClass
        {
            public ChildClass()
            {
                Console.WriteLine("ChildClassConstructor is called");
            }
        }
    
        public static void Main()
        {
            //will print that the Parent ctor is called, followed by printing that the child ctor is called
            ChildClass child = new ChildClass();
            //will print that the Parent ctor is called, followed by printing that the child ctor is called
            ParentClass childinparentbox = new ChildClass();
            //will print that the Parent ctor is called
            ParentClass parent = new ParentClass();
            //At this point there are 3 object instances in memory
            //by the way, this can't be done. Can't store a parent in a child: a parent is-not-a child
            ChildClass parentinchildbox = new ParentClass();
            
        }
    }
