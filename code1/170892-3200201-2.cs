    public interface IA
    {
      void DoSomething();
    }
    
    public interface IB
    {
      void DoSomethingElse();
    }
    public class A : IA
    {
      void DoSomething() { }
    }
    
    public class B : IB
    {
      void DoSomethingElse() { }
    }
    public class C : IA, IB
    {
      private A m_A = new A();
      private B m_B = new B();
      public void DoSomething() { m_A.DoSomething(); }
      
      public void DoSomethingElse() { m_B.DoSomethingElse(); }
    }
