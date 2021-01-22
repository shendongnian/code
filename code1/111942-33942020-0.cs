    public interface IHaveAProblem
    {
        string Issue { get; set; }
    }
    public class IHaveAProblemComparer : IComparer<IHaveAProblem>, IEqualityComparer<IHaveAProblem>
    {
        public int Compare(IHaveAProblem x, IHaveAProblem y)
        {
            return string.Compare(x.Issue, y.Issue);
        }
        public bool Equals(IHaveAProblem x, IHaveAProblem y)
        {
            return string.Equals(x.Issue, y.Issue);
        }
        public int GetHashCode(IHaveAProblem obj)
        {
            return obj.GetHashCode();
        }
    }
