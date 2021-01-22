    // .Net 3.5 or later
    public static void MoveMatches<T>(this LinkedList<T> first, Predicate<T> match, LinkedList<T> other)
    {
        LinkedListNode<T> current = first.First;
        while (current != null)
        {
            LinkedListNode<T> next = current.Next;
            if (match(current.Value))
            {
                other.AddLast(current.Value); // other.AddLast(current) also works
                first.Remove(current);
            }
            current = next;
        }
    }
    // for strings that start with "W"
    LinkedList<string> a = ...
    LinkedList<string> b = ...
    a.MoveMatches(x => x.StartsWith("W"), b);
