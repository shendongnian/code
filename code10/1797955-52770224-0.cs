    var fin = new List<string>();
    foreach (var item in lst)
    {
        foreach (var n in num)
        {
            if (item.Contains(n))
            {
                fin.Add(item);
                break;
            }
        }
    }
