    return new DirectoryInfo(directory)
        .EnumerateFiles(searchPattern)
        .OrderBy(f => f.CreationTime,
                 order == "A" ? Comparer<DateTime>.Default
                              : new DescendingComparer<DateTime>;
    // ...
    public DescendingComparer<T> : Comparer<T>
    {
        public override int Compare(T x, T y)
        {
            return Comparer<T>.Default.Compare(y, x);
        }
    }
    public FunkyComparer<T> : Comparer<T>
    {
        public override int Compare(T x, T y)
        {
            // funky comparison logic goes here
        }
    }
