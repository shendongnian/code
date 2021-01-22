    public class ListHelper<T>
    {
        public static bool ContainsAllItems(List<T> a, List<T> b)
        {
            return !b.Except(a).Any();
        }
    }
