	var result = input1
		.Union(input2)
		.ScanUnion(Tuple.Create(ImmutableQueue<string>.Empty, (string)null, false, false),
			(state, _) => state.Item1.IsEmpty
				? Tuple.Create(state.Item1, (string)null, false, false)     //empty queue, so don't emit item
				: state.Item1.Dequeue().IsEmpty         //At least one item: dequeue unless only one item, then emit either way
					? Tuple.Create(state.Item1, state.Item1.Peek(), true, true) //maintain last item, enter Fake-EmptyState
					: Tuple.Create(state.Item1.Dequeue(), state.Item1.Peek(), false, true),
			(state, s) => state.Item3
				? Tuple.Create(state.Item1.Dequeue().Enqueue(s), (string)null, false, false)
				: Tuple.Create(state.Item1.Enqueue(s), (string)null, false, false)
		)
		.Where(t => t.Item4)
		.Select(t => t.Item2);
