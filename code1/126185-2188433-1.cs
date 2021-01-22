    public IEnumerable<T> Where(IEnumerable<T> source, Predicate<T> predicate)
    {
       foreach(T item in source)
           if (predicate(item))
              yield return item;
    }
    public bool HasFoo(Item item) { return item.Foo; }
    Parallel.ForEach(Where(itemList, HasFoo), DoStuff);
