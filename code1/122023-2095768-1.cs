    public class MyDerived : StoreBase
    {
       // .. other stuff
       protected override void Initialize()
       {
           // Leave out, intentionally or accidentally, the following:
           // base.Initialize(); 
       }
    }
