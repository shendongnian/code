    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using Remotion.Linq;
    using Remotion.Linq.Parsing.ExpressionVisitors.TreeEvaluation;
    
    class CustomQueryModelGenerator : QueryModelGenerator
    {
    	public CustomQueryModelGenerator(INodeTypeProviderFactory nodeTypeProviderFactory, IEvaluatableExpressionFilter evaluatableExpressionFilter, ICurrentDbContext currentDbContext)
    		: base(nodeTypeProviderFactory, evaluatableExpressionFilter, currentDbContext)
    	{ }
    
    	public override QueryModel ParseQuery(Expression query) => base.ParseQuery(Preprocess(query));
    
    	private Expression Preprocess(Expression query)
    	{
    		// return new YourExpressionVisitor().Visit(query);               
    		return query;
    	}
    }
