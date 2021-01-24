    class Program
    {
        static void Main(string[] args)
        {
            Foo my_text1 = new Foo("My text 1");
            Foo my_text2 = my_text1;
    
            my_text1 = new Foo("My text 2");
            Console.WriteLine("First text --> " + my_text1); // It prints My text 2
            Console.WriteLine("Second text -->" + my_text2); // It prints My text 1
    
            Foo text_1 = new Foo("Example 1");
            object text_2 = text_1;
    
            text_1 = new Foo("Example 2");
            Console.WriteLine("First example --> " + text_1); // It prints Example 2
            Console.WriteLine("Second example -->" + text_2);// It prints Example 1
        }
    }
    
    class Foo
    {
        private readonly string _name;
    
        public Foo(string name)
        {
            _name = name;
        }
    
        public override string ToString()
        {
            return _name;
        }
    }
