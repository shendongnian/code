    public interface IA
    {
      void DoA();
    }
    
    public interface IB
    {
      void DoB();
    }
    
    public class A : IA
    {
      public void DoA() { Console.WriteLine("A"); }
    }
    
    public class B : IB
    {
      public void DoB() { Console.WriteLine("B"); }
    }
    
    public class MultipleInheritanceExample : IA, IB
    {
      private IA m_A = new A();
      private IB m_B = new B();
    
      public void DoA() { m_A.DoA(); }
      public void DoB() { m_B.DoB(); }
    
    }
