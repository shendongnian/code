    /// <summary>
    /// ICollectionExtensions
    /// </summary>
    internal static class ICollectionExtensions
    {
        public static void AddNew<T>(this ICollection<T> self, T data)
        {
            if (self != null && !self.Contains(data))
            {
                self.Add(data);
            }
        }
    }
