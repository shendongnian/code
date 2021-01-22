	public class SpecialQueue<T>
	{
		LinkedList<T> list = new LinkedList<T>();
		public void Enqueue(T t)
		{
			list.AddLast(t);
		}
		public T Dequeue()
		{
			var result = list.First.Value;
			list.RemoveFirst();
			return result;
		}
		public T Peek()
		{
			return list.First.Value;
		}
		public bool Remove(T t)
		{
			return list.Remove(t);
		}
                public int Count { get { return list.Count; } }
	}
