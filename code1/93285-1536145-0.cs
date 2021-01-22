    public class Person
    {
        public void DoSomethingWith(SomeStrategy strategy)
        {
            strategy.DoSomething(this);
        }
     }
