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
        public List<Expression<Func<T, object>>> Expressions { get; private set; }
        public DataExtractor() {
            Expressions = new List<Expression<Func<T, object>>>();
        }
        public IDataExtractor<T> WithProperty(Expression<Func<T, object>> expr)
        {
            Expressions.Add(expr);
            return this;
        }
    }
