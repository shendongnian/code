    public class MyListBoxItemComparer : IComparer<MyListBoxItem>
    {
        public int Compare(MyListBoxItem x, MyListBoxItem y)
        {
            if (x.StudyName == y.StudyName)
            {
                return x.StudyDate.CompareTo(y.StudyDate);
            }
            return String.Compare(x.StudyName, y.StudyName, StringComparison.Ordinal);
        }
    }
