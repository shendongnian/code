        static Action<object, TValue> MakeSetter<TValue>(Type tclass, PropertyInfo propInfo)
		{
            var t = lambda.Expression.Parameter(typeof(object), "t");
            var v = lambda.Expression.Parameter(typeof(TValue), "v");
			// return (t, v) => ((tclass)t).prop = (tproperty)v
            return (Action<object, TValue>)
				lambda.Expression.Lambda(
					lambda.Expression.Call(
						lambda.Expression.Convert(t, tclass),
						propInfo.GetSetMethod(),
						lambda.Expression.Convert(v, propInfo.PropertyType)),
					t,
					v)
				.Compile();
        }
