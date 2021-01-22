    public interface IRepository<T> where T : IMyType
    {
        IList<T> GetAll();
    }
    public class RepositoryFactory
    {
        public static IRepository<T> createRepository<T>(ISessionBuilder sb) where T : IMyType
        {
            // create repository
        }
    }
    public interface IMyType
    {
        bool Active { get; }
        string Value { get; }
    }
    private static IList<T> GetList(RequestForm form) where T : IMyType
    {
        // get base list
        IRepository<T> repository = RepositoryFactory.createRepository<T>(new HybridSessionBuilder());
        IList<T> myTypes = repository.GetAll();
        // create results list
        IList<T> result = new List<T>();
        // iterate for active + used list items
        foreach (T myType in myTypes)
        {
            if (myType.Active || form.SolutionType.Contains(myType.Value))
            {
                result.Add(myType);
            }
        }
        // return sorted results
        return result.OrderBy(o => o.DisplayOrder).ToList();
    }
