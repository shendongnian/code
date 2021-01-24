    public interface IBasicOverviewModel
    {
    }
    public class BasicOverviewModel<T, TChild> : IBasicOverviewModel where TChild : IBasicOverviewModel
    {
        public T OverViewModel { get; set; }
        public IEnumerable<TChild> ChildOverviewModelCollection { get; set; }
    }
    public class EndpointOverviewModel<T> : IBasicOverviewModel
    {
        public T OverViewModel { get; set; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var b = new BasicOverviewModel<string, BasicOverviewModel<int, EndpointOverviewModel<string>>>();
        }
    }
