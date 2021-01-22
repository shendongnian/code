csharp
    public static class CollectionExtensions
    {
        public static TCol AddRange<TCol, TItem>(this TCol destination, IEnumerable<TItem> source)
            where TCol : ICollection<TItem>
        {
            if(destination == null) throw new ArgumentNullException(nameof(destination));
            if(source == null) throw new ArgumentNullException(nameof(source));
            // don't cast to IList to prevent recursion
            if (destination is List<TItem> list)
            {
                list.AddRange(source);
                return destination;
            }
            foreach (var item in source)
            {
                destination.Add(item);
            }
            return destination;
        }
    }
