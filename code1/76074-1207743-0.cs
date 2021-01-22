    while (next != null) // && next != terminator)
    {
       node = next;
       next = next.Previous;
    
       if (IDs.Contains(Id))
       {
          move.Add(node);
          list.Remove(node);
       }
       else
       {
          foreach (var item in move)
          {
             list.AddBefore(node, item);
             node = node.Previous;
          }
          move.Clear(); 
       }
    
       if (next == null) 
       {
          foreach (var item in move)
          {
             list.AddFirst(item);
          }
          move.Clear();
       }
    }
