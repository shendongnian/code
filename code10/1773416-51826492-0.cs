    public static class EnumerableGroupOf
        {
            public static IEnumerable<IEnumerable<TSource>> RandomGroupOf<TSource>(this IEnumerable<TSource> source, int[] groupLengths)
            {
                Random random = new Random();
    
                var itemsLeft = source;
    
                while (itemsLeft.Any())
                {
                    var count = groupLengths[random.Next(0, groupLengths.Length)];
    
                    var items = itemsLeft.Take(count);
    
                    itemsLeft = itemsLeft.Skip(count);
    
                    yield return items;
                }
            }
        }
