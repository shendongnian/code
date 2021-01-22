	class DropOutStack<T>
	{
		private T[] items;
		private int top = 0;
		public DropOutStack(int capacity)
		{ 
			items = new T[capacity];
		}
		public void Push(T item)
		{
			items[top] = item;
			top = (top + 1) % items.Length;
		}
		public T Pop()
		{
			top = (items.Length + top - 1) % items.Length;
			return items[top];
		}
	}
