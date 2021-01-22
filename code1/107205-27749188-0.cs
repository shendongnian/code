		public static IEnumerable<T> AllButLast<T>(this IEnumerable<T> enumerable, int n = 1)
		{
			// for efficiency, handle degenerate n == 0 case separately 
			if (n == 0)
			{
				foreach (var item in enumerable)
					yield return item;
				yield break;
			}
			var queue = new Queue<T>(n);
			foreach (var item in enumerable)
			{
				if (queue.Count == n)
					yield return queue.Dequeue();
				queue.Enqueue(item);
			}
		}
