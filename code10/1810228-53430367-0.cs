    public interface IAnalyticResolver<TAnalytic, TOutput> where TAnalytic : IAnalytic<TOutput>
    {
    	TOutput Evaluate();
    }
    public interface IResolver
    {
    	IAnalyticResolver<TAnalyticImpl, TOutput> GetResolver<TAnalyticImpl, TOutput> () 
               where TAnalyticImpl : IAnalytic<TOutput>;
    }
