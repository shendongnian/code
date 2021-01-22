    public class ComplexDeviceFactory : IDeviceFactory
    {
         public virtual ISomething GetSomeInterface()
         { return new ComplexStuff(); }
       
         public virtual ISomethingElse GetSomeOtherInterface()
         { return new EvenMoreComplexStuff(); }
    }
