    public class ProjectFilter : FilterBase<Linq.Project>
    {
        public IQueryable<Linq.Project> GetFilter(IQueryable<Linq.Project> query)
        {
            //do stuff with query
            return query;
        }
    }
