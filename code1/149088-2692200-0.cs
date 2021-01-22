    public class UniqueAttribute : ValidationAttribute
    {
    	public Type DataContextType { get; private set; }
    	public Type EntityType { get; private set; }
    	public string PropertyName { get; private set; }
    
    	public UniqueAttribute(Type dataContextType, Type entityType, string propertyName)
    	{
    		DataContextType = dataContextType;
    		EntityType = entityType;
    		PropertyName = propertyName;
    	}
    
    	public override bool IsValid(object value)
    	{
    		string str = (string) value;
    		if (String.IsNullOrWhiteSpace(str))
    			return true;
    
    		// Cleanup the string
    		str = str.Trim();
    
    		// Construct the data context
    		ConstructorInfo constructor = DataContextType.GetConstructor(new Type[0]);
    		DataContext dataContext = (DataContext)constructor.Invoke(new object[0]);
    		
    		// Get the table
    		ITable table = dataContext.GetTable(EntityType);
    
    		// Get the property
    		PropertyInfo propertyInfo = EntityType.GetProperty(PropertyName);
    
    		// Expression: "entity"
    		ParameterExpression parameter = Expression.Parameter(EntityType, "entity");
    
    		// Expression: "entity.PropertyName"
    		MemberExpression property = Expression.MakeMemberAccess(parameter, propertyInfo);
    
    		// Expression: "value"
    		object convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
    		ConstantExpression rhs = Expression.Constant(convertedValue);
    
    		// Expression: "entity.PropertyName == value"
    		BinaryExpression equal = Expression.Equal(property, rhs);
    
    		// Expression: "entity => entity.PropertyName == value"
    		LambdaExpression lambda = Expression.Lambda(equal, parameter);
    
    		// Instantiate the count method with the right TSource (our entity type)
    		MethodInfo countMethod = QueryableCountMethod.MakeGenericMethod(EntityType);
    
    		// Execute Count() and say "you're valid if you have none matching"
    		int count = (int)countMethod.Invoke(null, new object[] { table, lambda });
    		return count == 0;
    	}
    
    	// Gets Queryable.Count<TSource>(IQueryable<TSource>, Expression<Func<TSource, bool>>)
    	private static MethodInfo QueryableCountMethod = typeof(Queryable).GetMethods().First(m => m.Name == "Count" && m.GetParameters().Length == 2);
    }
  
