    public class Something : IThis, IThat
    {
      public This DoerOfThis { set; }
      public That DoerOfThat { set; }
    
      public void DoThis()
      {
         DoerOfThis.DoThis();
      }
      public void DoThat()
      {
         DoerOfThat.DoThat();
      }
    }
