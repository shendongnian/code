    public static class Extensions
    {
        public static bool FoundInTree<T>(this IEnumerable<T> items, Func<T, bool> searchItem, Func<T, IEnumerable<T>> nestedItems)
        {
            foreach (var item in items)
            {
                if (searchItem.Invoke(item)) return true;
                if (nestedItems.Invoke(item).FoundInTree(searchItem, nestedItems)) return true;
            }
            return false;
        }
    
        public static bool RemoveFirstFromTree<T>(this ICollection<T> items, Func<T, bool> searchItem, Func<T, ICollection<T>> nestedItems)
        {
            foreach (var item in items.ToList())
            {
                if (searchItem.Invoke(item))
                {
                    items.Remove(item);
                    return true;
                }
                if (nestedItems.Invoke(item).RemoveFirstFromTree(searchItem, nestedItems))
                {
                    return true;
                }
            }
            return false;
        }
    
        public static bool FoundInTree<T>(this IEnumerable<T> items, Func<T, bool> searchItem, Func<T, IEnumerable<T>> nestedItems, out int count)
        {
            count = 0;
            foreach (var item in items)
            {
                if (searchItem.Invoke(item)) count++;
                if (nestedItems.Invoke(item).FoundInTree(searchItem, nestedItems, out int nestedCount)) count += nestedCount;
            }
            return count > 0;
        }
    
        public static bool RemoveAllFromTree<T>(this ICollection<T> items, Func<T, bool> searchItem, Func<T, ICollection<T>> nestedItems, out int count)
        {
            var isAnyRemoved = false;
            count = 0;
            foreach (var item in items.ToList())
            {
                if (searchItem.Invoke(item))
                {
                    items.Remove(item);
                    isAnyRemoved = true;
                    count++;
                }
                if (nestedItems.Invoke(item).RemoveAllFromTree(searchItem, nestedItems, out int nestedCount))
                {
                    isAnyRemoved = true;
                    count += nestedCount;
                }
            }
            return isAnyRemoved;
        }
    }
