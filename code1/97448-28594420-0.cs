    for (int i = 0; i < elements.Count; i++)
    {
        if (<condition>)
        {
            // Decrement the loop counter to iterate this index again, since later elements will get moved down during the remove operation.
            elements.RemoveAt(i--);
        }
    }
