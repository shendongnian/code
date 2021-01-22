	public class MinHeap<T> where T: IComparable
	{
		private List<T> m_Vector = new List<T>();
		private void Swap(int i, int j)
		{
			var tmp = m_Vector[i];
			m_Vector[i] = m_Vector[j];
			m_Vector[j] = tmp;
		}
		private void SiftUp(int i)
		{
			if (i == 0)
			{
				return;
			}
			int parent = (i - 1) / 2;
			if (m_Vector[i].CompareTo(m_Vector[parent]) >= 0)
			{
				return;
			}
			Swap(i, parent);
			SiftUp(parent);
		}
		private void SiftDown(int i)
		{
			int left = i * 2 + 1;
			if (left >= m_Vector.Count)
			{
				return;
			}
			var right = left + 1;
			var child = left;
			if (right < m_Vector.Count)
			{
				if (m_Vector[left].CompareTo(m_Vector[right]) > 0)
				{
					child = right;
				}
			}
			if (m_Vector[i].CompareTo(m_Vector[child]) <= 0)
			{
				return;
			}
			Swap(i, child);
			SiftDown(child);
		}
		public MinHeap()
		{
		}
		public MinHeap(IEnumerable<T> elements)
		{
			foreach(var element in elements)
			{
				Add(element);
			}
		}
		public int Count { get { return m_Vector.Count; } }
		public void Add(T element)
		{
			m_Vector.Add(element);
			SiftUp(m_Vector.Count - 1);
		}
		public T Top
		{
			get
			{
				if (m_Vector.Count == 0)
				{
					throw new InvalidOperationException();
				}
				return m_Vector[0];
			}
		}
		public T Fetch()
		{
			if (m_Vector.Count == 0)
			{
				throw new InvalidOperationException();
			}
			T result = m_Vector[0];
			m_Vector[0] = m_Vector[m_Vector.Count - 1];
			m_Vector.RemoveAt(m_Vector.Count - 1);
			SiftDown(0);
			return result;
		}
	}
