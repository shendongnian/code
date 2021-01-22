	class MyList<T> : MyBaseClass, DefaultListMethods<T>
	{
		public void Insert(int index, T item) { ... }
		public void RemoveAt(int index)       { ... }
		public T this[int index] {
			get { ... }
			set { ... }
		}
		public int Count {
			get { ... }
		}
	}
