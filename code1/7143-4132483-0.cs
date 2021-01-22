    static void Method<T, U>(this T obj, Expression<Func<T, U>> property)
    		{
    			var memberExpression = property.Body as MemberExpression;
    			//getter
    			U code = (U)obj.GetType().GetProperty(memberExpression.Member.Name).GetValue(obj, null);
    			//setter
    			obj.GetType().GetProperty(memberExpression.Member.Name).SetValue(obj, code, null);
    		}
