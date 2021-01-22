    public abstract class AbstractClass<T> where T : AbstractClass<T>
    {
        public static T MakeAbstractClass()
        {
            T value = (T)Activator.CreateInstance(typeof(T), true);
            // your processing logic
            return value;
        }
    }
    
    public class ConcreteClassA : AbstractClass<ConcreteClassA>
    {
        private ConcreteClassA()
        {
        }
    }
    
    public class ConcreteClassB : AbstractClass<ConcreteClassB>
    {
        private ConcreteClassB()
        {
        }
    }
