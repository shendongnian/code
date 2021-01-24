    public class ClassB
    {
        public int Number { get; set; }
        public List<string> Foo { get; set; }
    }
    
    public class ClassA
    {
        private ClassB classB;
        
        public ClassA(ClassB classB)
        {
            this.classB = classB;
        }
    }
    
    public class ClassC
    {
        private ClassB classB;
        
        public ClassC(ClassB classB)
        {
            this.classB = classB;
        }
    }
    
    int number = 10;
    var fooList = new List<string>();
    
    // both X1 and X2 have a reference to the same List so this is not thread safe.
    ClassB X1 = new ClassB() { Number = number, Foo = fooList };
    ClassB X2 = new ClassB() { Number = number, Foo = fooList };
    
    var classA = new ClassA(X1);
    var classB = new ClassB(X2);
