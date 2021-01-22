    public interface IA
    {
      IA DoSomething();
    }
    
    public interface IB
    {
      IB DoSomething();
    }
    
    public class Test : IA, IB
    {
      public IA DoSomething() { return this; }
    
      IA IA.DoSomething() { return this; }
      IB IB.DoSomething() { return this; }
    }
