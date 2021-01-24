    public void RemoveAt(int position)
    {
        // reference to current position in list
        Node current = head;
        // reference to previous position in list
        Node previous = null;
        // scan through the array to locate the item to remove
        for (int i = 0; i < position && current != null; i++)
        {
            // update previous reference
            previous = current;
            // step to next element in list
            current = current.Next;
        }
        if (previous != null && current != null)
        {
            previous.Next = current.Next;
        }
    }
