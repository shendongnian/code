    public class Car
    {
     // is event named correctly?
     public event EventHandler<EventArgs> SomethingHasHappened;
    
     private void MoveForward()
     {
      OnSomethingHasHappened();
     }
    
     // is the named correctly
     protected virtual void OnSomethingHasHappened()
     {
      EventHandler<EventArgs> locum = SomethingHasHappened;
      if(locum!= null)
      {
       locum(this, new EventArgs()); 
      }
     }
    }
