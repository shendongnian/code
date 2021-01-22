    public static IEnumerable<T> Backwards(this LinkedList<T> list)
    {
        LinkedListNode<string> node= list.Last;
        while (node != null)
        {
            yield return node.Value;
            node = node.Previous;
        }
    }
