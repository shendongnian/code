    static void Main(string[] args)
    {
        AbstractClass factory = new AbstractClass();
        // UpCast to the actual concrete type from the factory works
        ConcreteClassA test = (ConcreteClassA) factory.ClassFactory("A");
        // Or just pass back the abstract type
        AbstractClass test2 = factory.ClassFactory("B");
        // Compiler Error, no public constructor
        ConcreteClassA = new ConcreteClassA();
    }
