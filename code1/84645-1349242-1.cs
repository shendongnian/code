    public class ProjectFilter : FilterBase<Linq.Project>
    {
        public override IQueryable<Linq.Project> GetFilter(IQueryable<Linq.Project> query)
        {
            //do stuff with query
            return query;
        }
    }
