    public class MyClass
    {
                    // sender   arguments       <-----     Use this action instead of an event
         public Action<object, EventArgs> OnSomeEventOccured;
         public void SomeMethod()
         {
              if(OnSomeEventOccured!=null)
                  OnSomeEventOccured(this, null);
         }
    }
