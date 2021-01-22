    public enum SortOrder
    {
        Ascending = 0,
        Descending = 1
    }
    public class Sorter<T>
    {
        public SortOrder Direction { get; set; }
        public Func<T, object> Target { get; set; }
        public Sorter<T> NextSort { get; set; }
        public IOrderedEnumerable<T> ApplySorting(IEnumerable<T> source)
        {
            IOrderedEnumerable<T> result = Direction == SortOrder.Descending ?
                source.OrderByDescending(Target) : 
                source.OrderBy(Target);
            if (NextSort != null)
            {
                result = NextSort.ApplyNextSorting(result);
            }
            return result;
        }
        private IOrderedEnumerable<T> ApplyNextSorting
            (IOrderedEnumerable<T> source)
        {
            IOrderedEnumerable<T> result = Direction == SortOrder.Descending ?
                source.ThenByDescending(Target) :
                source.ThenBy(Target);
            return result;
        }
    }
