    public interface IRequestDetail
    {
    }
    public class MyRequestDetail : IRequestDetail
    {
    }
    public interface IRequest<T> where T : IRequestDetail
    {
        IList<T> Details { get; set; }
        // stuff
    }
    public class MyRequest<T> : IRequest<T>
        where T : IRequestDetail
    {
        public IList<T> Details { get; set; }
        // stuff
    }
    public class Consumer
    {
        public void MyFunction<T>(IRequest<T> request)
            where T : IRequestDetail
        {
        }
        public void Foo()
        {
            var test = new MyRequest<MyRequestDetail>();
            MyFunction(test);
        }
    }
