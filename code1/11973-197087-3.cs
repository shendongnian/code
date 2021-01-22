    IEnumerable Flatten(IEnumerable array)
    {
        foreach(var item in array)
        {
            if(item is IEnumerable)
            {
                foreach(var subitem in Flatten((IEnumerable)item))
                {
                    yield return subitem;
                }
            }
            else
            {
                yield return item;
            }
        }
    }
