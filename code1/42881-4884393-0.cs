    public static void SetModifiedProperty<T>(this System.Data.Objects.ObjectStateEntry state, Expression<Func<T>> action)
	{
		var body = (MemberExpression)action.Body;
		string propertyName = body.Member.Name;
		
		state.SetModifiedProperty(propertyName);
	}
