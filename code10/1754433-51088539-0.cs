    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace System.Data.Entity
    {
    	public static class DbQueryExtensions
    	{
    		public static IQueryable<T> BindTo<T>(this IQueryable<T> source, DbContext target)
    		{
    			var binder = new DbContextBinder(target);
    			var expression = binder.Visit(source.Expression);
    			var provider = binder.TargetProvider;
    			return provider != null ? provider.CreateQuery<T>(expression) : source;
    		}
    
    		class DbContextBinder : ExpressionVisitor
    		{
    			ObjectContext targetObjectContext;
    			public IQueryProvider TargetProvider { get; private set; }
    			public DbContextBinder(DbContext target)
    			{
    				targetObjectContext = ((IObjectContextAdapter)target).ObjectContext;
    			}
    			protected override Expression VisitConstant(ConstantExpression node)
    			{
    				if (node.Value is ObjectQuery objectQuery && objectQuery.Context != targetObjectContext)
    					return Expression.Constant(CreateObjectQuery((dynamic)objectQuery));
    				return base.VisitConstant(node);
    			}
    			ObjectQuery<T> CreateObjectQuery<T>(ObjectQuery<T> source)
    			{
    				var parameters = source.Parameters
    					.Select(p => new ObjectParameter(p.Name, p.ParameterType) { Value = p.Value })
    					.ToArray();
    				var query = targetObjectContext.CreateQuery<T>(source.CommandText, parameters);
    				query.MergeOption = source.MergeOption;
    				query.Streaming = source.Streaming;
    				query.EnablePlanCaching = source.EnablePlanCaching;
    				if (TargetProvider == null)
    					TargetProvider = ((IQueryable)query).Provider;
    				return query;
    			}
    		}
    	}
    }
