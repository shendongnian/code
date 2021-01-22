    public static Node Duplicate(Node n)
        {
            // handle the degenerate case of an empty list
            if (n == null) {
                return null;
            }
            // create the head node, keeping it for later return
            Node first = new Node();
            first.Data = n.Data;
            // the 'temp' pointer points to the current "last" node in the new list
            Node temp = first;
            n = n.Next;
            while (n != null)
            {
                Node n2 = new Node();
                n2.Data = n.Data;
                // modify the Next pointer of the last node to point to the new last node
                temp.Next = n2;
                temp = n2;
                n = n.Next;
            }
            return first;
        }
