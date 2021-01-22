    public class A
    {
        public virtual void SampleMethod() 
        {
            Console.WriteLine("lol");
        }
    }
    public class B : A
    {
        public override void SampleMethod()
        {
            base.SampleMethod();
        }
    }
    public class C : B
    {
        public override void SampleMethod()
        {
            base.SampleMethod();
        }
    }
