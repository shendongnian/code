    if (!ilist.IsReadOnly)
    {
       ilist.Add(4);
       ilist.Insert(0, 0); 
       ilist.Remove(3);
       ilist.RemoveAt(0);
    }
    else
    {
       // what were you planning to do if you were given a read only list anyway?
    }
     
