    public class SomeProblem : IHaveAProblem
    {
        public string Issue { get; set; }
        
        ...
        public int CompareTo(object obj)
        {
            return Issue.CompareTo(((SomeProblem)obj).Issue);
        }
    }
