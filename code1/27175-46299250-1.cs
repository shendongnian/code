    public abstract class Heap<T>
    {
        private List<T> m_Vector;
        private void Swap(int i, int j)
        {
            var tmp = m_Vector[i];
            m_Vector[i] = m_Vector[j];
            m_Vector[j] = tmp;
        }
        protected abstract int Compare(T a, T b);
        private void SiftUp(int i)
        {
            if (i == 0)
            {
                return;
            }
            int parent = (i - 1) / 2;
            if (Compare(m_Vector[i], m_Vector[parent]) >= 0)
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
                if (Compare(m_Vector[left], m_Vector[right]) > 0)
                {
                    child = right;
                }
            }
            if (Compare(m_Vector[i], m_Vector[child]) <= 0)
            {
                return;
            }
            Swap(i, child);
            SiftDown(child);
        }
        public Heap()
        {
            m_Vector = new List<T>();
        }
        public Heap(IEnumerable<T> elements)
        {
            m_Vector = new List<T>(elements);
            if (m_Vector.Count < 2)
            {
                return;
            }
            //
            // From the last parent, upwards, sift down. Each sift is O<1>.
            //
            for (int i = (m_Vector.Count - 2) / 2; i >= 0; i--)
            {
                SiftDown(i);
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
    public class MinHeap<T> : Heap<T> where T: IComparable 
    {
        protected override int Compare(T a, T b)
        {
            return a.CompareTo(b);
        }
        public MinHeap() : base()
        {
        }
        public MinHeap(IEnumerable<T> elements) : base(elements)
        {
        }
    }
    public class MaxHeap<T> : Heap<T> where T : IComparable
    {
        protected override int Compare(T a, T b)
        {
            return b.CompareTo(a);
        }
        public MaxHeap() : base()
        {
        }
        public MaxHeap(IEnumerable<T> elements) : base(elements)
        {
        }
    }
