    public class A : ITest<A>
    {
    }
    public class B : ITest<A>
    {
      private B() { }
    }
