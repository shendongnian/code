    public static partial class QueryableExtensions
    {
    	public static IQueryable<T> SelectMembers<T>(this IQueryable<T> source, params string[] memberNames)
    	{
    		var parameter = Expression.Parameter(typeof(T), "e");
    		var bindings = memberNames
    			.Select(name => Expression.PropertyOrField(parameter, name))
    			.Select(member => Expression.Bind(member.Member, member));
    		var body = Expression.MemberInit(Expression.New(typeof(T)), bindings);
    		var selector = Expression.Lambda<Func<T, T>>(body, parameter);
    		return source.Select(selector);
    	}
    }
