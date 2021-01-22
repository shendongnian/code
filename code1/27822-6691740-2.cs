    // Simple mutable structure. 
    // Method IncrementI mutates current state.
    struct Mutable
    {
        public Mutable(int i) : this() 
        {
            I = i;
        }
    
        public void IncrementI() { I++; }
          
        public int I {get; private set;}
    }
    // Simple class that contains Mutable structure
    // as readonly field
    class SomeClass 
    {
        public readonly Mutable mutable = new Mutable(5);
    }
        
    // Simple class that contains Mutable structure
    // as ordinary (non-readonly) field
    class AnotherClass 
    {
        public Mutable mutable = new Mutable(5);
    }
    class Program
    {
        void Main()
        {
            // Case 1. Mutable readonly field
            var someClass = new SomeClass();
            someClass.mutable.IncrementI();
            // still 5, not 6, because SomeClass.mutable field is readonly
            // and compiler creates temporary copy every time when you trying to
            // access this field
            Console.WriteLine(someClass.mutable.I);
    
            // Case 2. Mutable ordinary field
            var anotherClass = new AnotherClass();
            anotherClass.mutable.IncrementI();
    
            //Prints 6, because AnotherClass.mutable field is not readonly
            Console.WriteLine(anotherClass.mutable.I);
        }
    }
        
