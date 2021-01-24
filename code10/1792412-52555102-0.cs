    List<int> results = new List<int>();
    foreach(var item in lst)
    {
        if(item < 0)
        {
            results.Clear();
        }
        else
        {
            results.Add(item);
        }
    }
