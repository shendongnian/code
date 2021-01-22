    List<I> list = new List<I>();
    foreach (T[] arrayOfA in arrays)
    {
        list.AddRange(arrayOfA.Cast<I>());
    }
    return list.ToArray();
