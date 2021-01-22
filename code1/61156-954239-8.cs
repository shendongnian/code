    	public static void RemoveAll<T>(this IList<T> instance, Predicate<T> predicate)
		{
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            if (instance is T[])
                throw new NotSupportedException();
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
				for (int deleteIndex = instance.Count - 1; deleteIndex >= writeIndex; --deleteIndex)
				{
					instance.RemoveAt(deleteIndex);
				}
			}
		}
