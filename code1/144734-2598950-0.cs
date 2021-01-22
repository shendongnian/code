    class Wrapper
    {
       private A = new A(); //this is your closed .dll class
       public event EventHandler DoneThing;
       private void OnDoneThing()
       {
          if(DoneThing!=null)
          {
            DoneThing(this, EventArgs.Empty);
          }
       }
       public void DoThing()
       {
           A.DoThing();
           OnDoneThing();
       }
    }
