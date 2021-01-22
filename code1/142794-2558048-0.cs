    public class NameComparer : IComparer<IHaveName>
    {
        public int Compare(IHaveName x, IHaveName y)
        {
            return String.Compare(x.Name, y.Name);
        }
    }
