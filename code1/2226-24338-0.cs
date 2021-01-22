    public class AbstractClass
    {
        public AbstractClass ClassFactory(string args)
        {
            switch (args)
            {
                case "A":
                    return new ConcreteClassA();               
                case "B":
                    return new ConcreteClassB();               
                default:
                    return null;
            }
        }
    }
    
    public class ConcreteClassA : AbstractClass
    {
        internal ConcreteClassA(){ }
    }
    
    public class ConcreteClassB : AbstractClass
    {
        internal ConcreteClassB() {}
    }
