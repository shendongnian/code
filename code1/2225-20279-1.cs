    public abstract class AbstractClass{
     public static AbstractClass MakeAbstractClass(string args)
     {
        if (args == "a")
            return ConcreteClassA().GetConcreteClassA();
        if (args == "b")
            return ConcreteClassB().GetConcreteClassB();
     }
    }
    public class ConcreteClassA : AbstractClass
    {
      private ConcreteClassA(){}
      internal static ConcreteClassA GetConcreteClassA(){
           return ConcreteClassA();
      }
    }
    
    public class ConcreteClassB : AbstractClass
    {
      private ConcreteClassB(){}
      internal static ConcreteClassB Get ConcreteClassB(){
           return ConcreteClassB();
      }
    }
