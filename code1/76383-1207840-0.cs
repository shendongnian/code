    void Main()
    {	
    	var programmers = new List<Programmer>{ 
    		new Programmer { Name = "Turing", Number = Math.E}, 
    		new Programmer { Name = "Babbage", Number = Math.PI}, 
    		new Programmer { Name = "Lovelace", Number = Math.E}};
    	
    	
    	var rule0 = new Rule<string>() { Field = "Name", Operator = BinaryExpression.Equal, Value = "Turing" };
    	var rule1 = new Rule<double>() { Field = "Number", Operator = BinaryExpression.GreaterThan,  Value = 2.719 };
    	
    	var matched0 = RunRule<Programmer, string>(programmers, rule0);
    	matched0.Dump();
    	
    	var matched1 = RunRule<Programmer, double>(programmers, rule1);
    	matched1.Dump();
    	
    	var matchedBoth = matched0.Intersect(matched1);
    	matchedBoth.Dump();
    	
    	var matchedEither = matched0.Union(matched1);
    	matchedEither.Dump();
    }
    
    public IEnumerable<T> RunRule<T, V>(IEnumerable<T> foos, Rule<V> rule) {
    	
    		var fieldParam = Expression.Parameter(typeof(T), "f");
    		var fieldProp = Expression.Property (fieldParam, rule.Field);
    		var valueParam = Expression.Parameter(typeof(V), "v");
    		
    		BinaryExpression binaryExpr = rule.Operator(fieldProp, valueParam);
    		
    		var lambda = Expression.Lambda<Func<T, V, bool>>(binaryExpr, fieldParam, valueParam);
    		var func = lambda.Compile();
    		
    		foreach(var foo in foos) {
    			var result = func(foo, rule.Value);
    			if(result)
    				yield return foo;
    		}
    
    }
    
    public class Rule<T> {
    	public string Field { get; set; }
    	public Func<Expression, Expression, BinaryExpression> Operator { get; set; }
    	public T Value { get; set; }
    }
    
    public class Programmer {
    	public string Name { get; set; }
    	public double Number { get; set; }
    }
