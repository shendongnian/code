    public interface IRequest<T> where T : IRequestDetail
    {
        IList<T> Details { get; set; }
        // stuff
    }
    public class MyRequest : IRequest<MyRequestDetail>
    {
        public IList<MyRequestDetail> Details {get; set; }
        // stuff
    }
