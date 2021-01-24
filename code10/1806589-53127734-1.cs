    interface Product {}
     
    class ConcreteProductA : Product {}
     
    class ConcreteProductB : Product {}
     
    abstract class Creator
    {
        public abstract Product FactoryMethod(string type);
    }
     
    class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(string type)
        {
            switch (type)
            {
               case "A": return new ConcreteProductA();
               case "B": return new ConcreteProductB();
               default: throw new ArgumentException("Invalid type", "type");
            }
        }
     }
