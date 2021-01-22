    public abstract class AbstractClass
    {
        public static AbstractClass MakeAbstractClass(string args)
        {
            if (args == "a")
                return (AbstractClass)Activator.CreateInstance(typeof(ConcreteClassA), true);
            if (args == "b")
                return (AbstractClass)Activator.CreateInstance(typeof(ConcreteClassB), true);
        }
    }
    
    public class ConcreteClassA : AbstractClass
    {
        private ConcreteClassA()
        {
        }
    }
    
    public class ConcreteClassB : AbstractClass
    {
        private ConcreteClassB()
        {
        }
    }
