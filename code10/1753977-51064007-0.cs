    public class PrimaryKeyFilter<TEntity>
    	where TEntity : class
    {
    	object valueBuffer;
    	Func<object[], object> valueArrayConverter;
    
    	public PrimaryKeyFilter(DbContext dbContext)
    	{
    		var keyProperties = dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties;
    
    		// Create value buffer type (Tuple) from key properties
    		var valueBufferType = TupleTypes[keyProperties.Count - 1]
    			.MakeGenericType(keyProperties.Select(p => p.ClrType).ToArray());
    
    		// Build the delegate for converting value array to value buffer
    		{
    			// object[] values => new Tuple(values[0], values[1], ...)
    			var parameter = Expression.Parameter(typeof(object[]), "values");
    			var body = Expression.New(
    				valueBufferType.GetConstructors().Single(),
    				keyProperties.Select((p, i) => Expression.Convert(
    					Expression.ArrayIndex(parameter, Expression.Constant(i)),
    					p.ClrType)));
    			valueArrayConverter = Expression.Lambda<Func<object[], object>>(body, parameter).Compile();
    		}
    
    		// Build the predicate expression
    		{
    			var parameter = Expression.Parameter(typeof(TEntity), "e");
    			var valueBuffer = Expression.Convert(
    				Expression.Field(Expression.Constant(this), nameof(this.valueBuffer)),
    				valueBufferType);
    			var body = keyProperties
    				// e => e.{propertyName} == valueBuffer.Item{i + 1}
    				.Select((p, i) => Expression.Equal(
    					Expression.Property(parameter, p.Name),
    					Expression.Property(valueBuffer, $"Item{i + 1}")))
    				.Aggregate(Expression.AndAlso);
    			Predicate = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
    		}
    	}
    
    	public Expression<Func<TEntity, bool>> Predicate { get; }
    
    	public void SetValues(params object[] values) =>
    		valueBuffer = valueArrayConverter(values);
    
    	static readonly Type[] TupleTypes =
    	{
    		typeof(Tuple<>),
    		typeof(Tuple<,>),
    		typeof(Tuple<,,>),
    		typeof(Tuple<,,,>),
    		typeof(Tuple<,,,,>),
    		typeof(Tuple<,,,,,>),
    		typeof(Tuple<,,,,,,>),
    		typeof(Tuple<,,,,,,,>),
    	};
    }
