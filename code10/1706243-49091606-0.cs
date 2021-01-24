    public class PageRepository
    {
        public PageViewModel GetPageById(string oid)
        {
            using (var db = new AppDbContext())
            {
                Page page = GetPagesWithStatus(db.Pages, StatusType.Published);
                
                return GetPageView(page);
            }
        }
    
        internal IQueryable<Page> GetPagesWithStatus(IQueryable<Page> query, StatusType statusType)
        {
            return query.Where(p => p.Alias == p.Alias);
        }
    
    }
