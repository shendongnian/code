    var list1 = new List<object>() { 1, 2, 3 };
    var list2 = new List<object>() { 4, 5, 6 };
    var list3 = new List<object>() { 1, 2, 3 };
    List<List<object>> mainList = new List<List<object>>() { list1, list2, list3 };
    mainList.Distinct(new ListEqualityComparer<object>());
    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<T> list)
        {
            int hash = 17;
            foreach (var item in list)
            {
                hash += 31 * item.GetHashCode();
            }
            return hash;
        }
    }
