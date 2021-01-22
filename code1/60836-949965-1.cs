    public class Person
    {
        public virtual void DoSomething()
        {
            // do something here
        }
    }
    public class Employee : Person
    {
        public override void DoSomething()
        {
            base.DoSomething();
        }
    }
