    class test
	{
		public string Code { get; set; }
		public int Id { get; set; }
		public override string ToString()
		{
			return Code + " " + Id;
		}
	}
    class MainClass
	{
		public static void Main(string[] args)
		{
            List<test> list = new List<test>();
    
            list.Add(new test { Code = "1", Id = 5 });
            list.Add(new test { Code = "2", Id = 6 });
            list.Add(new test { Code = "3", Id = 7 });
            list.Add(new test { Code = "4", Id = 8 });
    
            list.AsQueryable()
                 .Select(DynamicSelect<test>("Id"))
                 .ToList()
                 .ForEach(Console.WriteLine);
        }
    }
	public static Expression<Func<T, T>> DynamicSelect<T>(string fields)
    {
		var members = fields.Split(',').Select(f => f.Trim());
		var targetType = typeof(T);
		var parameter = Expression.Parameter(targetType, "x");
		var bindings = new List<MemberBinding>();
		var target = Expression.Constant(null, targetType);
		foreach (var name in members)
		{
			var targetMember = Expression.PropertyOrField(target, name);
			var sourceMember = Expression.PropertyOrField(parameter, name);
            bindings.Add(Expression.Bind(targetMember.Member, sourceMember));
		}
		var body = Expression.MemberInit(Expression.New(targetType), bindings);
		return Expression.Lambda<Func<T, T>>(body, parameter);
	}
