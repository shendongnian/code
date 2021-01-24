	public static class Extensions
	{
		public static IEnumerable<TRecord[]> Batch<TRecord>(this IEnumerable<TRecord> seq, int batchSize)
		{
			T[] buffer = null;
			int offset = 0;
			foreach (var record in seq)
			{
				if (buffer == null)
				{
					buffer = new T[batchSize];
					offset = 0;
				}
				buffer[offset++] = record;
				if (offset == batchSize)
				{
					yield return buffer;
					buffer = null;
				}
			}
			if (buffer != null)
			{
				yield return buffer.Take(offset).ToArray();
			}
		}
	}
