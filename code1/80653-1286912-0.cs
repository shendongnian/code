    public abstract class SavableBase
    {
      protected abstract void Add ();
      protected abstract void Update ();
    
      public void Save ()
      {
         if( !saved ){
            Add();
         } else {
            Update();
         }
      }
    }
