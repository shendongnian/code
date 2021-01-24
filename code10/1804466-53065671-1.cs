        public class RangeModelType<TFrom, TTo> : InputObjectGraphType<RangeModel<TFrom, TTo>>
	    {
			public RangeModelType()
			{
				var fromType = typeof(TFrom);
				Field(x => x.From, fromType.IsGenericType && fromType.GetGenericTypeDefinition() == typeof(Nullable<>));
				var toType = typeof(TTo);
				Field(x => x.To, toType.IsGenericType && toType.GetGenericTypeDefinition() == typeof(Nullable<>));
			}
	    }
