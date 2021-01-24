    static class MyExtensions
    {
      public static ReadOnlyCollection<TEntry> AsReadOnly<TEntry>(this TEntry[] arr)
        => Array.AsReadOnly(arr);
    }
