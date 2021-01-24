    using System.Linq.Dynamic.Core;
    
    static Expression<Func<TSource, dynamic>> DynamicFields<TSource>(IEnumerable<string> fields)
    {
    	var source = Expression.Parameter(typeof(TSource), "o");
    	var properties = fields
    		.Select(f => typeof(TSource).GetProperty(f))
    		.Select(p => new DynamicProperty(p.Name, p.PropertyType))
    		.ToList();
    	var resultType = DynamicClassFactory.CreateType(properties, false);
    	var bindings = properties.Select(p => Expression.Bind(resultType.GetProperty(p.Name), Expression.Property(source, p.Name)));
    	var result = Expression.MemberInit(Expression.New(resultType), bindings);
    	return Expression.Lambda<Func<TSource, dynamic>>(result, source);
    }
