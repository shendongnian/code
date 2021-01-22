    interface IFoo {
        int Bar { get; }
    }
    
    class Foo : IFoo {
        public int Bar { get; set; }
    }
    
    class Program {
    
        public static void Main() {
            
            IFoo myFoo = new Foo() {
                Bar = 5 // valid
            };
            int five = myFoo.Bar; // valid
            myFoo.Bar = 6; // compilation error
        }
    }
