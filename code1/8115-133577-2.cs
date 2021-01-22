    public static void RemoveFirstWhere<T>(this LinkedList<T> list, Predicate<T> p)
    {
        LinkedListNode<T> nodeToRemove;
        var node = list.First;
        while (node != null) //O(n)
        {
            if (p(node.Value))
            {
                nodeToRemove = node;
                break;
            }
            node = node.Next;
        }
        if (nodeToRemove != null)
            list.Remove(nodeToRemove); //O(1)
    }
