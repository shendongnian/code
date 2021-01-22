    LinkedList<BD> list = new LinkedList<BD>(b[arg].Values);
    LinkedListNode<BD> node = list.Last;
    LinkedListNode<BD> terminator = null;
    
    while (node != null && node != terminator) {
    	if (IDs.Contains(node.Value.DocumentVersionId)) {
    		LinkedListNode<BD> tempNode = node;
    		node = node.Previous;
    		
    		list.Remove(tempNode);
    		list.AddFirst(tempNode);
    		if (terminator == null) terminator = tempNode;
    	} else {
    		node = node.Previous;
    	}
    }
