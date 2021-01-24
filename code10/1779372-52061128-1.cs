    class Test : IJobTask
    {
        public void Start(string val = "")
        {
            throw new NotImplementedException();
        }
    }
    public interface ITest
    {
        void MyMethod<T>(T model) where T : IJobTask;
    }
    public class ConcreteTest : ITest
    {
        public void MyMethod<T>(T model) where T : IJobTask
        {
        }
    }
    public class Main
    {
        public Main()
        {
            var ct = new ConcreteTest();
            ct.MyMethod(new Test());
        }
    }
