	public static class X
	{
		public static IObservable<IList<TSource>> Buffer<TSource>(this IObservable<TSource> source, Func<TSource, int> sizeSelector, int maxSize, TimeSpan bufferTimeSpan)
		{
			BehaviorSubject<Unit> queue = new BehaviorSubject<Unit>(new Unit()); //our time-out mechanism
			return source
				.Union(queue.Delay(bufferTimeSpan))
				.ScanUnion(
					(list: ImmutableList<TSource>.Empty, size: 0, emitValue: (ImmutableList<TSource>)null),
					(state, item) => { // item handler
						var itemSize = sizeSelector(item);
						var newSize = state.size + itemSize;
						if (newSize > maxSize)
						{
							queue.OnNext(Unit.Default);
							return (ImmutableList<TSource>.Empty.Add(item), itemSize, state.list);
						}
						else
							return (state.list.Add(item), newSize, null);
					},
					(state, _) => { // time out handler
						queue.OnNext(Unit.Default); 
						return (ImmutableList<TSource>.Empty, 0, state.list); 
					}
				)
				.Where(t => t.emitValue != null)
				.Select(t => t.emitValue.ToList());
		}
	}
