    public static class LinqExtensions
    {
        public static IEnumerable<T> Where(this IEnumerable<T> source, Predicate<T> predicate)
        {
           foreach(T item in source)
               if (predicate(item))
                  yield return item;
        }
    }
    public bool HasFoo(Item item) { return item.Foo; }
    Parallel.ForEach(itemList.Where(HasFoo), DoStuff);
