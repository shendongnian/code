    /// <summary>
    /// Represents paged data source.
    /// </summary>
    /// <typeparam name="T">
    /// Data item type.
    /// </typeparam>
    public interface IPagedDataSource<T>
    {
        /// <summary>
        /// Fetches particular page from data source.
        /// </summary>
        /// <param name="pageNumber">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// Page size.
        /// </param>
        /// <returns></returns>
        IReadOnlyList<T> GetPage(int pageNumber, int pageSize);
    }
    /// <summary>
    /// Represents paged data source, built on top of <see cref="IQueryable{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">
    /// Data item type.
    /// </typeparam>
    public sealed class QueryablePagedDataSource<T> : IPagedDataSource<T>
    {
        private readonly IQueryable<T> query;
        /// <summary>
        /// Initializes <see cref="QueryablePagedDataSource{T}"/> instance.
        /// </summary>
        /// <param name="query">
        /// <see cref="IQueryable{T}"/> to use as paged data source.
        /// </param>
        public QueryablePagedDataSource(IQueryable<T> query)
        {
            this.query = query;
        }
        /// <summary>
        /// Fetches particular page from data source.
        /// </summary>
        /// <param name="pageNumber">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// Page size.
        /// </param>
        /// <returns></returns>
        public IReadOnlyList<T> GetPage(int pageNumber, int pageSize) => query
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToList();
    }
    /// <summary>
    /// Implements basic pagination logic.
    /// </summary>
    /// <typeparam name="T">
    /// Data item type.
    /// </typeparam>
    public sealed class Paginator<T>
    {
        private readonly int pageSize;
        private readonly IPagedDataSource<T> dataSource;
        private readonly IDictionary<int, IReadOnlyList<T>> pages;
        /// <summary>
        /// Initializes <see cref="Paginator{T}"/> instance.
        /// </summary>
        /// <param name="dataSource">
        /// Paged data source.
        /// </param>
        /// <param name="pageSize">
        /// Page size.
        /// </param>
        public Paginator(IPagedDataSource<T> dataSource, int pageSize)
        {
            this.dataSource = dataSource;
            this.pageSize = pageSize;
            pages = new Dictionary<int, IReadOnlyList<T>>();
        }
        /// <summary>
        /// Gets current page number.
        /// </summary>
        public int CurrentPageNumber { get; private set; }
        /// <summary>
        /// Gets current page.
        /// </summary>
        public IReadOnlyList<T> CurrentPage
        {
            get
            {
                if (pages.Count == 0)
                {
                    NavigateTo(0);
                }
                return pages[CurrentPageNumber];
            }
        }
        /// <summary>
        /// Navigates to particular page.
        /// </summary>
        /// <param name="pageNumber">
        /// Page number to navigate to.
        /// </param>
        public void NavigateTo(int pageNumber)
        {
            CurrentPageNumber = pageNumber;
            if (!pages.ContainsKey(CurrentPageNumber))
            {
                var page = dataSource.GetPage(CurrentPageNumber, pageSize);
                pages.Add(CurrentPageNumber, page);
            }
        }
        /// <summary>
        /// Navigates to the next page.
        /// </summary>
        public void Next() => NavigateTo(CurrentPageNumber + 1);
        /// <summary>
        /// Navigates to the previous page.
        /// </summary>
        public void Previous()
        {
            if (CurrentPageNumber > 1)
            {
                NavigateTo(CurrentPageNumber - 1);
            }
        }
        /// <summary>
        /// Exports fetched data as a list.
        /// </summary>
        /// <returns>
        /// A list, containing fetched data. Data is ordered by page number.
        /// </returns>
        public List<T> ToList() => pages
            .OrderBy(_ => _.Key)
            .SelectMany(_ => _.Value)
            .ToList();
    }
