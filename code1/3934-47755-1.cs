    list.Sort();
    Int32 index = list.Count - 1;
    while (index > 0)
    {
        if (list[index] == list[index - 1])
        {
            if (index < list.Count - 1)
                (list[index], list[list.Count - 1]) = (list[list.Count - 1], list[index]);
            list.RemoveAt(list.Count - 1);
            index--;
        }
        else
            index--;
    }
