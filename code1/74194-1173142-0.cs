    List<string> Items = ...
    for(int i = Items.Count - 1; i >= 0; i--)
    {
       if(Items[i] == "DELETE ME")
       {
          Items.RemoveAt(i);
       }
    }
