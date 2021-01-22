    public static Node Duplicate(Node n)
    {
         // Handle the degenerate case of an empty list
         if (n == null) return null;
    
         // Create the head node, keeping it for later return
         Node first = new Node();
         Node current = first;
    
         do
         {
             // Copy the data of the Node
             current.Data = n.Data;
             current = (current.Next = new Node());
             n = n.Next;
         } while (n != null)
    
         return first;    
    }
