    List<string> listbox = new List<string>();
    List<object> toRemove = new List<object>();
    foreach (string item in listbox)
    {
        string removelistitem = "OBJECT";
        if (item.Contains(removelistitem))
        {
            toRemove.Add(item);
        }
    }
    foreach (string item in toRemove)
    {
        listbox.Remove(item);
    }
