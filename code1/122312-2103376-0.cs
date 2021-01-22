    //Reference type
    class Foo {
        public int I { get; set; }
    }
    
    //Value type
    struct Boo {
        //I know, that mutable structures are evil, but it only an example
        public int I { get; set; }
    }
    
    
    class Program
    {
        //Passing reference type by value
        //We can change reference object (Foo::I can changed), 
        //but not reference itself (f must be the same reference 
        //to the same object)
        static void ClassByValue1(Foo f) {
            //
            f.I++;
        }
    
        //Passing reference type by value
        //Here I try to change reference itself,
        //but it doesn't work!
        static void ClassByValue2(Foo f) {
            //But we can't change the reference itself
            f = new Foo { I = f.I + 1 };
        }
    
        //Passing reference typ by reference
        //Here we can change Foo object
        //and reference itself (f may reference to another object)
        static void ClassByReference(ref Foo f) {
            f = new Foo { I = -1 };
        }
    
        //Passing value type by value
        //We can't change Boo object
        static void StructByValue(Boo b) {
            b.I++;
        }
    
        //Passing value tye by reference
        //We can change Boo object
        static void StructByReference(ref Boo b) {
            b.I++;
        }
    
        static void Main(string[] args)
        {
            Foo f = new Foo { I = 1 };
            
            //Reference object passed by value.
            //We can change reference object itself, but we can't change reference
            ClassByValue1(f);
            Debug.Assert(f.I == 2);
    
            ClassByValue2(f);
            //"f" still referenced to the same object!
            Debug.Assert(f.I == 2);
    
            ClassByReference(ref f);
            //Now "f" referenced to newly created object.
            //Passing by references allow change referenced itself, 
            //not only referenced object
            Debug.Assert(f.I == -1);
    
            Boo b = new Boo { I = 1 };
            
            StructByValue(b);
            //Value type passes by value "b" can't changed!
            Debug.Assert(b.I == 1);
    
            StructByReference(ref b);
            //Value type passed by referenced.
            //We can change value type object!
            Debug.Assert(b.I == 2);
            
            Console.ReadKey();
        }
    
    }
