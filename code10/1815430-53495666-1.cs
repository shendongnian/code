    public class Node<T> where T: Node<T>
    {
        public T Next, Prev;
        /// <summary>
        /// Sorts the nodes from <paramref name="first"/> to <paramref name="last"/> inclusive, in place.
        /// </summary>
        public static void MergeSort(T first, T last, IComparer<T> comparer)
        {
            // return if 0 or 1 nodes
            if (ReferenceEquals(first, last))
                return;
            // optimization for two nodes
            if (ReferenceEquals(first.Next, last))
            {
                if (comparer.Compare(first, last) > 0)
                    MoveBefore(first, last, last);
                return;
            }
            var mid = Midpoint(first, last);
            // a little messy here ... get the nodes before and after each
            // segment before MergeSort reorders it,
            // then determine the new beginning and end from those
            var p1 = first.Prev;
            var p2 = mid.Next;
            MergeSort(first, mid, comparer);
            p1 = p1.Next;
            mid = p2.Prev;
            var ln = last.Next;
            MergeSort(p2, last, comparer);
            p2 = mid.Next;
            last = ln.Prev;
            // merge p1 and p2
            for (;;)
            {
                for (;; p1 = p1.Next)
                {
                    if (ReferenceEquals(p1, p2))
                        return;
                    if (comparer.Compare(p1, p2) > 0)
                        break;
                }
                var start = p2;
                do
                {
                    if (ReferenceEquals(p2, last))
                    {
                        MoveBefore(p1, start, p2);
                        return;
                    }
                    p2 = p2.Next;
                }
                while (comparer.Compare(p1, p2) > 0);
                MoveBefore(p1, start, p2.Prev);
            }
        }
        /// <summary>
        /// Moves the nodes from <paramref name="first"/> and <paramref name="last"/> inclusive
        /// from where they are in the list to before <paramref name="target"/>.
        /// </summary>
        public static void MoveBefore(T target, T first, T last)
        {
            first.Prev.Next = last.Next;
            last.Next.Prev = first.Prev;
            (first.Prev = target.Prev).Next = first;
            (last.Next = target).Prev = last;
        }
        /// <summary>
        /// Returns the node midway between <paramref name="first"/> and <paramref name="last"/>.
        /// If there are an even number of nodes, returns the last node in the first half.
        /// </summary>
        /// <remarks>
        /// Undefined if <paramref name="first"/> and <paramref name="last"/> aren't in the same list.
        /// </remarks>
        public static T Midpoint(T first, T last)
        {
            for (;; first = first.Next)
                if (ReferenceEquals(first, last) || ReferenceEquals(first, last = last.Prev))
                    return first;
        }
    }
