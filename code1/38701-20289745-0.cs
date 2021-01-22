    public class A
    {
      private underwear myUnderwear;
    
      public ChangeUnderwear(B friend, underwear newUnderwear) 
      {
        if (friend == null) return;
        myUnderwear = newUnderwear
      }
    }
    
    public sealed class B
    {
      private B() {};
      private B inst;
      private MessWithA(A a)
      {
        a.ChangeUnderwear(this, new Thong());
      }
    }
