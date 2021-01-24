    static IEnumerable<Item> PrioritySort(this IEnumerable<Item> items, int recentItemCount)
    {
      return items
        .Select((item, originalPosition) => new { item, originalPosition }) 
        .OrderBy(o => GetBucket(o.item, o.originalPosition, recentItemCount))
        .ThenBy(o => o.originalPosition)
        .Select(o => o.item);
    }
