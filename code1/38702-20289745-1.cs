    interface IB
    { ... }
    
    public sealed class B : IB
    {
      private B() {};
      public IB CreateB()
      {
        return (IB)new B();
      }
      private MessWithA(A a)
      {
        a.ChangeUnderwear(this, new Thong());
      }
    }
