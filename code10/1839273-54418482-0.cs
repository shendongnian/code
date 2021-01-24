    public class MyBase { }
    public class MyClass : MyBase { }
    public class A
    {
      public void DoSomething(MyBase b) { }
      public void DoSomething(MyClass c) { }
    }
