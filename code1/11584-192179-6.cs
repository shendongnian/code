	/// This trait declares default methods of IList<T>
	public trait DefaultListMethods<T> : IList<T>
	{
		// Methods without bodies must be implemented by another 
		// trait or by the class
		public void Insert(int index, T item);
		public void RemoveAt(int index);
		public T this[int index] { get; set; }
		public int Count { get; }
		
		public int IndexOf(T item)
		{
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < Count; i++)
				if (comparer.Equals(this[i], item))
					return i;
			return -1;
		}
		public void Add(T item)
		{
			Insert(Count, item);
		}
		public void Clear()
		{	// Note: the class would be allowed to override the trait 
			// with a better implementation, or select an 
			// implementation from a different trait.
			for (int i = Count - 1; i >= 0; i--)
				RemoveAt(i);
		}
		public bool Contains(T item)
		{
			return IndexOf(item) != -1;
		}
		public void CopyTo(T[] array, int arrayIndex)
		{
			foreach (T item in this)
				array[arrayIndex++] = item;
		}
		public bool IsReadOnly
		{
			get { return false; }
		}
		public bool Remove(T item)
		{
			int i = IndexOf(item);
			if (i == -1)
				return false;
			RemoveAt(i);
			return true;
		}
		System.Collections.IEnumerator 
			System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
				yield return this[i];
		}
	}
