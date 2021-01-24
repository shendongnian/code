    public class MyTypeWith100Properties
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
    }
    public interface IDataExtractor<T>
    {
        IDataExtractor<T> WithProperty(Expression<Func<T, object>> expr);
    }
    public class DataExtractor<T> : IDataExtractor<T>
    {
        public IDataExtractor<T> WithProperty(Expression<Func<T, object>> expr)
        {
            Console.WriteLine(expr.ToString());
            return this;
        }
    }
