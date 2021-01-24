    void Main()
    {
    	//IQueryable<MyEntity> MyEntityList = Enumerable.Empty<MyEntity>().AsQueryable();
    	var MyEntityList = new List<MyEntity>();
    	MyEntityList.Add(new MyEntity { DeliverOn = new DateTimeOffset(2018, 01, 01, 00, 00, 00, TimeSpan.Zero) });
    	DateTimeOffset? dt1 = new DateTimeOffset(2018, 01, 01, 00, 00, 00, TimeSpan.Zero);
    	var expr = WhereEquals<MyEntity, DateTimeOffset?>(MyEntityList.AsQueryable(), t => t.DeliverOn, (DateTimeOffset?)dt1);
    	Console.WriteLine($"{expr.Count()} item(s) found");
    
    	// Output:
    	// selector.GetType() is System.Linq.Expressions.Expression`1[System.Func`2[UserQuery + MyEntity, System.Nullable`1[System.DateTimeOffset]]]
    	// typeof(TValue) is System.Nullable`1[System.DateTimeOffset]
    	// value.GetType() is System.DateTimeOffset
    	// 1 item(s) found
    }
    
    public class MyEntity
    {
    	public DateTimeOffset? DeliverOn;
    }
    
    public static IQueryable<TSource> WhereEquals<TSource, TValue>(IQueryable<TSource> source, Expression<Func<TSource, TValue>> selector, TValue value)
    {
    	Console.WriteLine($"selector.GetType() is {selector.GetType()}");
    	Console.WriteLine($"typeof(TValue) is {typeof(TValue)}");
    	Console.WriteLine($"value.GetType() is {value.GetType()}");
    	return source.Where(Expression.Lambda<Func<TSource, bool>>(Expression.Equal(selector.Body, Expression.Constant(value, typeof(TValue))), selector.Parameters));
    }
