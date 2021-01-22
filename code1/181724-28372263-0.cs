	public static class EnumerationExtensions
	{
		public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> input, int count)
		{
			if (count <= 0)
				yield break;
			var inputList = input as IList<T>;
			if (inputList != null)
			{
				int last = inputList.Count;
				int first = last - count;
				if (first < 0)
					first = 0;
				for (int i = first; i < last; i++)
					yield return inputList[i];
			}
			else
			{
				// Use a ring buffer. We have to enumerate the input, and we don't know in advance how many elements it will contain.
				T[] buffer = new T[count];
				int index = 0;
				count = 0;
				foreach (T item in input)
				{
					buffer[index] = item;
					index = (index + 1) % buffer.Length;
					count++;
				}
				// The index variable now points at the next buffer entry that would be filled. If the buffer isn't completely
				// full, then there are 'count' elements preceding index. If the buffer *is* full, then index is pointing at
				// the oldest entry, which is the first one to return.
				//
				// If the buffer isn't full, which means that the enumeration has fewer than 'count' elements, we'll fix up
				// 'index' to point at the first entry to return. That's easy to do; if the buffer isn't full, then the oldest
				// entry is the first one. :-)
				//
				// We'll also set 'count' to the number of elements to be returned. It only needs adjustment if we've wrapped
				// past the end of the buffer and have enumerated more than the original count value.
				if (count < buffer.Length)
					index = 0;
				else
					count = buffer.Length;
				// Return the values in the correct order.
				while (count > 0)
				{
					yield return buffer[index];
					index = (index + 1) % buffer.Length;
					count--;
				}
			}
		}
		public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> input, int count)
		{
			if (count <= 0)
				return input;
			else
				return input.SkipLastIter(count);
		}
		private static IEnumerable<T> SkipLastIter<T>(this IEnumerable<T> input, int count)
		{
			var inputList = input as IList<T>;
			if (inputList != null)
			{
				int first = 0;
				int last = inputList.Count - count;
				if (last < 0)
					last = 0;
				for (int i = first; i < last; i++)
					yield return inputList[i];
			}
			else
			{
				// Aim to leave 'count' items in the queue. If the input has fewer than 'count'
				// items, then the queue won't ever fill and we return nothing.
				Queue<T> elements = new Queue<T>();
				foreach (T item in input)
				{
					elements.Enqueue(item);
					if (elements.Count > count)
						yield return elements.Dequeue();
				}
			}
		}
	}
