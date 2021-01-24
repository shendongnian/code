    public interface IAnalytic { }
    public interface IAnalytic<TInput, TOutput> : IAnalytic
    {
        TOutput Calculate(TInput input);
    }
    public interface IAnalyticResolver<T, TOutput> where T : IAnalytic
    {
        TOutput Evaluate();
    }
    public interface IResolver<TOutput>
    {
        IAnalyticResolver<TAnalyticImpl, TOutput> GetResolver<TAnalyticImpl>() where TAnalyticImpl : IAnalytic;
    }
    public class ParseAnalytic : IAnalytic<string, int>
    {
        public int Calculate(string input) => int.Parse(input);
    }
    public class IntResolver : IResolver<int>
    {
        public IAnalyticResolver<TAnalyticImpl, int> GetResolver<TAnalyticImpl>() where TAnalyticImpl : IAnalytic
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IResolver<int> r = new IntResolver();
            int result = r.GetResolver<ParseAnalytic>().Evaluate();
        }
    }
