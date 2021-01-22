	static decimal ParallelPartitionerPi(int steps)
	{
		decimal sum = 0.0;
		decimal step = 1.0 / (decimal)steps;
		object obj = new object();
		Parallel.ForEach(
			Partitioner.Create(0, steps),
			() => 0.0,
			(range, state, partial) =>
			{
				for (int i = range.Item1; i < range.Item2; i++)
				{
				    decimal x = (i - 0.5) * step;
				    partial += 4.0 / (1.0 + x * x);
				}
				return partial;
			},
			partial => { lock (obj) sum += partial; });
		return step * sum;
	}
