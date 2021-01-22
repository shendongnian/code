    using System;
    
    class Base
    {
        public virtual event EventHandler Foo
        {
            add
            {
                Console.WriteLine("Base Foo.add called");
            }
            remove
            {
                Console.WriteLine("Base Foo.remove called");
            }
        }
    }
    
    class Derived : Base
    {
        public override event EventHandler Foo
        {
            add
            {
                Console.WriteLine("Derived Foo.add called");
            }
            remove
            {
                Console.WriteLine("Derived Foo.remove called");
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            Base x = new Derived();
            
            x.Foo += (sender, args) => {};
        }
    }
