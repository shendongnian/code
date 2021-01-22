    /// <summary>
    /// in place linked list sort using quick sort.
    /// </summary>
    public static void QuickSort<T>(this LinkedList<T> linkedList, IComparer<T> comparer)
    {
        if (linkedList == null || linkedList.Count <= 1) return; // there is nothing to sort
        SortImpl(linkedList.First, linkedList.Last, comparer);
    }
    private static void SortImpl<T>(LinkedListNode<T> head, LinkedListNode<T> tail, IComparer<T> comparer)
    {
        if (head == tail) return; // we shall not exceed borders.
        void Swap(LinkedListNode<T> a, LinkedListNode<T> b)
        {
            var tmp = a.Value;
            a.Value = b.Value;
            b.Value = tmp;
        }
        var pivot = tail;
        var node = head;
        while (node.Next != pivot)
        {
            if (comparer.Compare(node.Value, pivot.Value) > 0)
            {
                Swap(pivot, pivot.Previous);
                Swap(node, pivot);
                pivot = pivot.Previous;
            }
            else node = node.Next;
        }
        if (comparer.Compare(node.Value, pivot.Value) > 0)
        {
            Swap(node, pivot);
            pivot = node;
        }
        // if head or tail is equal to pivot we should stop recursion.
        if (head != pivot) SortImpl(head, pivot.Previous, comparer);
        if (tail != pivot) SortImpl(pivot.Next, tail, comparer);
    }
