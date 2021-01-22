    // replaces existing Evaluator signature.  I would personally ditch this
    // definition and just use Func<TValue, TKey> instead
    public delegate TKey Evaluator<TKey, TValue>(TValue item);
    
    class PriorityQueue<T>
    {
        Evaluator<int, T> Evaluate;
        Heap<int, T> m_heap;
    
        public PriorityQueue(Evaluator<int, T> evaluateFunction)
        {
            Evaluate = evaluateFunction;
            m_heap = new Heap<int, T>(HeapType.MinHeap);
        }
    
        public void Insert(T element)
        {
            m_heap.Insert(Evaluate(element), element);
        }
    }
