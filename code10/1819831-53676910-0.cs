    public class ListComparer : IComparer<string>
    {
        public List<string> ComparisonList { get; set; }
        public ListComparer(List<string> comparisonList)
        {
            ComparisonList = comparisonList;
        }
        public int Compare(string x, string y)
        {
            return ComparisonList?.IndexOf(x).CompareTo(ComparisonList.IndexOf(y)) ?? 1;
        }
    }
