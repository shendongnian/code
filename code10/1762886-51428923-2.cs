    public class ClassB
    {
        public int Number { get; set; }
        public List<string> Foo { get; set; }
    }
    
    public class ClassA
    {
        private ClassB classB;
        public ClassA(ClassB classB) => this.classB = classB;
    }
    
    public class ClassC
    {
        private ClassB classB;
        public ClassC(ClassB classB) => this.classB = classB;
    }
    
    int number = 10;
    var fooList = new List<string>();
    
    ClassB X1 = new ClassB() { Number = number, Foo = fooList };
    
    // both A and B have the same reference to X1 so you will need to consider thread safety if you are modifying X1
    var classA = new ClassA(X1);
    var classB = new ClassB(X1);
