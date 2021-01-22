    Simple Sample code :<br>
        class Foo
        {
            public string Bar { get; set; }
        }
    
        struct Bar
        {
            public int FooBar { get; set; }
            public Foo BarFoo { get; set; }
        }
      
        public class AddPrinterConnection
        {
            public static void Main()
            {
    
                int n = default(int);
                Foo f = default(Foo);
                Bar b = default(Bar);
    
                Console.WriteLine(n);
    
                if (f == null) Console.WriteLine("f is null");
    
                Console.WriteLine("b.FooBar = {0}",b.FooBar);
    
                if (b.BarFoo == null) Console.WriteLine("b.BarFoo is null");
              
            }
        }
