    class A
    {
        static A() {
           Console.WriteLine("Creating the global instance of class A....");
        }
        public static void displayName()
        {
            Console.WriteLine("myName");
        }
    
        public static void displayAge()
        {
            Console.WriteLine("myAge");
        }
    }
    
    
    class B
    {
        public void Foo()
        {
            A.displayName();
            A.displayAge();           
        }
    }
