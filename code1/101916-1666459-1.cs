    public class SimpleDeviceFactory : IDeviceFactory
    {
         public virtual ISomething GetSomeInterface()
         { return Something.Empty; }
       
         public virtual ISomethingElse GetSomeOtherInterface()
         { return new SomeSimpleConreteImplementation(); }
    }
