    void Main()
    {
      var final = UpdateBulk((Problem p) => new Problem{CatId = 1,SubCatId = 2, ListId=3});
     // final is of type Expression<Func<T,T>>, which can be used for further processing
      
      final.Dump();
    }
    
    public static Expression<Func<T, T>> UpdateBulk<T>(Expression<Func<T, T>> updateFactory) where T : IBaseEntity, new()
    {
    	Expression<Func<T, T>> modifiedExpression = x => new T() { ModifiedBy = "Test", ModifiedDate = DateTime.Now };
    
    	var result = Combine(updateFactory, modifiedExpression);
    
    	return result;
    }
    
    
    static Expression<Func<TSource, TDestination>> Combine<TSource, TDestination>(
    	params Expression<Func<TSource, TDestination>>[] selectors)
    {
    	var param = Expression.Parameter(typeof(TSource), "x");
    	return Expression.Lambda<Func<TSource, TDestination>>(
    		Expression.MemberInit(
    			Expression.New(typeof(TDestination).GetConstructor(Type.EmptyTypes)),
    			from selector in selectors
    			let replace = new ParameterReplaceVisitor(
    				  selector.Parameters[0], param)
    			from binding in ((MemberInitExpression)selector.Body).Bindings
    				  .OfType<MemberAssignment>()
    			select Expression.Bind(binding.Member,
    				  replace.VisitAndConvert(binding.Expression, "Combine")))
    		, param);
    }
    
    class ParameterReplaceVisitor : ExpressionVisitor
    {
    	private readonly ParameterExpression from, to;
    	public ParameterReplaceVisitor(ParameterExpression from, ParameterExpression to)
    	{
    		this.from = from;
    		this.to = to;
    	}
    	protected override Expression VisitParameter(ParameterExpression node)
    	{
    		return node == from ? to : base.VisitParameter(node);
    	}
    }
    
    public abstract class IBaseEntity
    {
    	public System.DateTime CreatedDate { get; set; }
    	public string CreatedBy { get; set; }
    
    	public System.DateTime ModifiedDate { get; set; }
    	public string ModifiedBy { get; set; }
    
    	public string DeletedBy { get; set; }
    }
    
    public class Problem : IBaseEntity
    {
    	public int CatId { get; set; }
    
    	public int SubCatId { get; set; }
    
    	public int ListId { get; set; }
    }
