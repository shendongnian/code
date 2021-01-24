    public void RemoveAt(int position)
    {
        // reference to current position in list
        Node current = head;
        // check for empty list
        if (current == null)
            return;
        // special case if we're removing the first item in the list
        if (position == 0)
        {
            root = current.Next;
            return;
        }
        
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
