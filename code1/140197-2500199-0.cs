    public interface IRelationPredicateBucket
    { }
    public interface ISearchExpression
    {
        IRelationPredicateBucket Get();
    }
    public interface IGrid
    {
        ISearchExpression Search { get; set; }
    }
    public class ProjectSearch : ISearchExpression
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public IRelationPredicateBucket Get()
        {
            throw new NotImplementedException();
        }
    }
    public class Project : IGrid
    {
        public Project()
        {
            this.Search = new ProjectSearch();
        }
        public ISearchExpression Search { get; set; }
    }
