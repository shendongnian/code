    public class A
    {
      private underwear myUnderwear;
    
      public ChangeUnderwear(B.IdCard friend, underwear newUnderwear) 
      {
        if (friend == null) return;
        myUnderwear = newUnderwear
      }
    }
    
    public class B
    {
      public sealed class IdCard
      {
        private IdCard() {};
        private static bool created = false;
        public IDCard GetId()
        {
          if (created) throw new Exception("Why are two people asking for the same ID?!?");
          created = true;
          return new IDCard();
        }
      }
      private static IdCard id;
      
      static B()
      {
        id = IDCard.CreateId();
        if (id == false) throw new Tantrum("Panic: Someone stole my ID card before I could grab it");
      }
     
      private void MessWithA(A a)
      {
        a.ChangeUnderwear(id, new Thong());
      }
    }
