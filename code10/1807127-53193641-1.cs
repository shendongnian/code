	public static class DUnionExtensions
	{
		public class DUnion<T1, T2>
		{
			public DUnion(T1 t1)
			{
				Type1Item = t1;
				Type2Item = default(T2);
				IsType1 = true;
			}
	
			public DUnion(T2 t2, bool ignored) //extra parameter to disambiguate in case T1 == T2
			{
				Type2Item = t2;
				Type1Item = default(T1);
				IsType1 = false;
			}
	
			public bool IsType1 { get; }
			public bool IsType2 => !IsType1;
	
			public T1 Type1Item { get; }
			public T2 Type2Item { get; }
		}
	
		public static IObservable<DUnion<T1, T2>> Union<T1, T2>(this IObservable<T1> a, IObservable<T2> b)
		{
			return a.Select(x => new DUnion<T1, T2>(x))
				.Merge(b.Select(x => new DUnion<T1, T2>(x, false)));
		}
	
		public static IObservable<TState> ScanUnion<T1, T2, TState>(this IObservable<DUnion<T1, T2>> source,
				TState initialState,
				Func<TState, T1, TState> type1Handler,
				Func<TState, T2, TState> type2Handler)
		{
			return source.Scan(initialState, (state, u) => u.IsType1
				? type1Handler(state, u.Type1Item)
				: type2Handler(state, u.Type2Item)
			);
		}
	}
