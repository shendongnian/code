    LinkedListNode<T> nodeToRemove;
    LinkedListNode node = myLinkedList.First;
    while (node != null) //O(n)
    {
        if (node.Value.id == searchId)
        {
            nodeToRemove = node;
            break;
        }
        node = node.Next;
    }
    if (nodeToRemove != null)
        myLinkedList.Remove(nodeToRemove); //O(1)
