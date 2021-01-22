    public static class LinkedListExtensions
    {
        public static void RemoveAll<T>(this LinkedList<T> linkedList,
                                        Func<T, bool> predicate)
        {
            for (LinkedListNode<T> node = linkedList.First; node != null; )
            {
                LinkedListNode<T> next = node.Next;
                if (predicate(node.Value))
                    linkedList.Remove(node);
                node = next;
            }
        }
    }
