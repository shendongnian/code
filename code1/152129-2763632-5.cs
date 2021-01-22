    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> source, int index, int pageSize)
        {
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
        }    
    
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage 
        { 
            get 
            {
                return (PageIndex > 0);
            }
        }
        
        public bool HasNextPage 
        { 
            get
            {
                return (PageIndex * PageSize) <= TotalCount;
            } 
        }     
     }
