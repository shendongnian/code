     class Foo
        {
            public int abc;
            public Foo()
            {
                abc = 3;
            }
    
            public int ABC
            {
                get { return abc; }
                set { abc = value; }
            }
    
        }
    
        class Bar : Foo
        {
            public Bar() : base()
            {
                abc = 2;
            }
        } 
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Bar b = new Bar();
                Console.WriteLine(b.ABC);
                Console.ReadLine();
    
            }
        }
