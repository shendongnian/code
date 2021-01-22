    	public static void RemoveAll<T>(this IList<T> instance, Predicate<T> predicate)
		{
			var list = instance as List<T>;
			if (list != null)
			{
				list.RemoveAll(predicate);
				return;
			}
			int writeIndex = 0;
			for (int readIndex = 0; readIndex < instance.Count; readIndex++)
			{
				var item = instance[readIndex];
				if (predicate(item)) continue;
				if (readIndex != writeIndex)
				{
					instance[writeIndex] = item;
				}
				++writeIndex;
			}
			if (writeIndex != instance.Count)
			{
				try
				{
					for (int deleteIndex = instance.Count - 1; deleteIndex >= writeIndex; --deleteIndex)
					{
						instance.RemoveAt(deleteIndex);
					}
				}
				catch (NotSupportedException)
				{
					// Can't remove so just null out
					// Will be '0' for non-reference types.
					for (int deleteIndex = instance.Count - 1; deleteIndex >= writeIndex; --deleteIndex)
					{
						instance[deleteIndex] = default(T);
					}
				}
			}
		}
