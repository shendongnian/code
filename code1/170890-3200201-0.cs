    public class A
    {
      public void DoSomething() { }
    }
    
    public static class B
    {
      public static void DoSomethingElse(this A target)
    }
    
    public class C : A
    {
    }
