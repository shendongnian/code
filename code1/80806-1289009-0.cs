        public static T MoveAheadAndReturn<T>(LinkedList<T> ll, Predicate<T> pred)
        {
            if (ll == null)
                throw new ArgumentNullException("ll");
            if (pred == null)
                throw new ArgumentNullException("pred");
            LinkedListNode<T> node = ll.First;
            T value = default(T);
            while (node != null)
            {
                value = node.Value;
                if (pred(value))
                {
                    ll.Remove(node);
                    ll.AddFirst(node);
                    break;
                }
                node = node.Next;
            }
            return value;
        }
