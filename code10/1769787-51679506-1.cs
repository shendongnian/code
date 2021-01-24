    public class Example1 : Base<Object1>
    {
        protected override IService GetService()
        {
            return new Service1();
        }
    }
