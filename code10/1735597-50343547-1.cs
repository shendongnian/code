    void Main()
    {
    	var store = new Store
    	{
    	  Id = 1,
    	  Abbreviation = "ABC",
    	  Enabled = true,
    	  Name = "DEF"
    	};
    	
       var filter =  new Filter<Store>
       {
       	Ids = new HashSet<int>(new [] {1,2,3,4}),
    	Abbreviation = "GFABC",
    	Enabled = true,
    	Name = "SDEFGH",
    	ShowAll = false
       }
       
       var expression = filter.ToExpression(store);
       
       var parameterType = Expression.Parameter(typeof(Store), "obj");
       
       // Generate Func from the Expression Tree
       Func<Store,bool> func = Expression.Lambda<Func<Store,bool>>(expression,parameterType).Compile();
    }
    
    public class Store
    {
    	public int Id {get; set;}
    	
    	public string Name {get; set;}
    	
    	public string Abbreviation { get; set; }
    	
    	public bool Enabled { get; set; } 	
    }
    
    public class Filter<T> where T : Store
    {
    	public HashSet<int> Ids { get; set; }
    
    	public string Name { get; set; }
    
    	public string Abbreviation { get; set; }
    	
    	public bool Enabled {get; set;}
    
    	public bool ShowAll { get; set; } = true;
    
    	public Expression ToExpression(T data)
    	{
    		var parameterType = Expression.Parameter(typeof(T), "obj");
    		
    		var expressionList = new List<Expression>();
    
    		if (Ids != null && Ids.Count > 0)
    		{
    			MemberExpression idExpressionColumn = Expression.Property(parameterType, "Id");
    
    			ConstantExpression idConstantExpression = Expression.Constant(data.Id, typeof(int));
    
    			MethodInfo filtersMethodInfo = typeof(HashsetExtensions).GetMethod("Contains", new[] { typeof(HashSet<int>), typeof(int) });
    
    			var methodCallExpression = Expression.Call(null, filtersMethodInfo, idExpressionColumn, idConstantExpression);
    
    			expressionList.Add(methodCallExpression);
    		}
    		if (!string.IsNullOrEmpty(Name))
    		{
    			MemberExpression idExpressionColumn = Expression.Property(parameterType, "Name");
    
    			ConstantExpression idConstantExpression = Expression.Constant(data.Name, typeof(string));
    
    			MethodInfo filtersMethodInfo = typeof(StringExtensions).GetMethod("Contains", new[] { typeof(string), typeof(string) });
    
    			var methodCallExpression = Expression.Call(null, filtersMethodInfo, idExpressionColumn, idConstantExpression);
    
    			expressionList.Add(methodCallExpression);
    		}
    		if (!string.IsNullOrEmpty(Abbreviation))
    		{
    			MemberExpression idExpressionColumn = Expression.Property(parameterType, "Abbreviation");
    
    			ConstantExpression idConstantExpression = Expression.Constant(data.Abbreviation, typeof(string));
    
    			MethodInfo filtersMethodInfo = typeof(StringExtensions).GetMethod("Contains", new[] { typeof(string), typeof(string) });
    
    			var methodCallExpression = Expression.Call(null, filtersMethodInfo, idExpressionColumn, idConstantExpression);
    
    			expressionList.Add(methodCallExpression);
    		}
    		if (!ShowAll)
    		{
    			MemberExpression idExpressionColumn = Expression.Property(parameterType, "Enabled");
    
    			var binaryExpression = Expression.Equal(idExpressionColumn, Expression.Constant(true, typeof(bool)));
    
    			expressionList.Add(binaryExpression);
    		}
    		
    		if (expressionList.Count == 0)
    		{
    			expressionList.Add(BinaryExpression.Constant(true));
    		}
    
    		// Aggregate List<Expression> data into single Expression
    		
    		var returnExpression = expressionList.Skip(1).Aggregate(expressionList.First(), (expr1,expr2) => Expression.And(expr1,expr2));		
    		
    		return returnExpression;
    		
    		// Generate Func<T,bool> - Expression.Lambda<Func<T,bool>>(returnExpression,parameterType).Compile();
    	}
    	
    }
    
    public static class StringExtensions
    {
    	public static bool Contains(this string source, string subString)
    	{
    		return source?.IndexOf(subString, StringComparison.OrdinalIgnoreCase) >= 0;
    	}
    }
    
    public static class HashsetExtensions
    {
    	public static bool Contains(this HashSet<string> source, string subString)
    	{
    		return source.Contains(subString,StringComparer.OrdinalIgnoreCase);
    	}
    }
