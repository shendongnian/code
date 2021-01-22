    LinkedListNode<E> node = list.First;
    while (node != null)
    {
        var next = node.Next;
        if (node.Value == x) {
            list.Remove(e);
        }
        node = next;
    }
