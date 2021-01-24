    class Parent
    {
         protected EventHandler Handler { get; private set; }
         public event EventHandler Event
         {
              add => Handler += value;
              remove => Handler -= value;
         }
    }
    class Child : Parent
    {
        private void SomeMethodInDerivedClass()
        {
             var handlers = Handler.GetInvocationList();
             // ...
        }
    }
