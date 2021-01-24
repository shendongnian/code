    public abstract class ClassA
    {
        public abstract void DoSomething();
    }
    public class ClassB : ClassA
    {
        public override void DoSomething()
        {
            //Do something that is ClassB specific
        }
    }
    public class ClassC : ClassA
    {
        public override void DoSomething()
        {
            //Do something that is ClassC specific
        }
    }
