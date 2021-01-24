    void Main()
    {
    	var predicate = PredicateBuilder.True<KiteCadastrado>();
    	var filter = new KiteFilter();//your kitefiltered object 
    	filter.MarcaId = "98272";//fill in your own values here
    	filter.NumSerie = "Unit E";
    
    	if(filter.MarcaId != null){
    		predicate = predicate.And(p => p.MarcaId == filter.MarcaId);
    	}
    	if(filter.NumSerie != null){
    		predicate = predicate.And(p => p.NumSerie == filter.NumSerie);
    	}
        //fill out remaining values
    	db.KiteCadastrados.AsExpandable().Where(predicate).Count().Dump();//Added AsExpandable()
    	
    }
    
    public class KiteFilter
    {
    	public String MarcaId { get; set; }
    	public String NumSerie { get; set; }
    }
    
    public static class PredicateBuilder
    {
    	public static Expression<Func<T, bool>> True<T>() { return f => true; }
    	public static Expression<Func<T, bool>> False<T>() { return f => false; }
    
    	public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
    														Expression<Func<T, bool>> expr2)
    	{
    		var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
    		return Expression.Lambda<Func<T, bool>>
    			  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
    	}
    
    	public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
    														 Expression<Func<T, bool>> expr2)
    	{
    		var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
    		return Expression.Lambda<Func<T, bool>>
    			  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
    	}
    }
