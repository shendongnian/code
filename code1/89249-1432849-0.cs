    public void Delete(int rangeStart, int rangeEnd) {
        Node previousNode = null, currentNode = Head;
        while (currentNode != null) {
            if (currentNode.Data >= rangeStart && currentNode.Data <= rangeEnd) {
                if (previousNode == null) {
                    Initial = currentNode.Next;
                }
                else {
                    previousNode.Next = currentNode.Next;
                }
            }
            else {
                previousNode = currentNode;
            }
            currentNode = currentNode.Next;
        }
    }
