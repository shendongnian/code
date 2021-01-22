    public class FooCorpClass
    {
      // This class is defined in a 3rd party library and thus can't be changed
    }
    
    public class MyFoo : FooCorpClass, MarshalByRef
    {
      // I can't do this because MarshalByRef isnt' an interface
    }
