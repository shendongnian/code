    static void MoveElementUp(XElement element)
    {
        // Walk backwards until we find an element - ignore text nodes
        XNode previousNode = element.PreviousNode;
        while (previousNode != null && !(previousNode is XElement))
        {
            previousNode = previousNode.PreviousNode;
        }
        if (previousNode == null)
        {
            throw new ArgumentException("Nowhere to move element to!");
        }
        element.Remove();
        previousNode.AddBeforeSelf(element);
    }
