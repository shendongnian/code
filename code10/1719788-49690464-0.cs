    static class MyExtensions
    {
      public static ReadOnlyCollection<TEntry> AsReadOnly<TEntry>(this IList<TEntry> li)
        => new ReadOnlyCollection<TEntry>(li);
    }
