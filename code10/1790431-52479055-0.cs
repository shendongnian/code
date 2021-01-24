    HasNext         (bool)
    HasPrevious     (bool)
    Next            (int)
    PagedResults    (IEnumerable<T>)
    PageNumbers     (List<PagedObjectPages>)
    Pages           (int)
    Previous        (int)
    Total           (int)
    Last            (int)
    First           (int)
    HasFirst        (bool)
    HasLast         (bool)
==================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Pager
    {
    
        /// <summary>
        /// Pages the specified items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="numberOfResults">The number of results.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public static PagedObject<T> Paging<T>(this IEnumerable<T> items, int numberOfResults, int page = 1, int pageNumbersCount = 10, bool includeLast = true)
        {
            page = Math.Max(1, page);
            int itemCount = items.Count();
            float pages = numberOfResults >= itemCount || numberOfResults == 0 ? 1 : ((float)itemCount / (float)numberOfResults);
            int _pages = Convert.ToInt32(Math.Ceiling(pages));
    
            var _return = numberOfResults >= itemCount ? items : page > _pages ? items.Reverse().Take(numberOfResults).Reverse() : items.Skip(((page - 1) * numberOfResults)).Take(numberOfResults);
    
            return CreatePagedObjects(page, pageNumbersCount, itemCount, _pages, _return);
    
        }
    
        private static PagedObject<T> CreatePagedObjects<T>(int page, int pageNumbersCount, int itemCount, int pages, IEnumerable<T> result)
        {
            int _page = page;
            int _pageNumbersCount = pageNumbersCount;
            int _itemCount = itemCount;
            int _pages = pages;
            var _result = result.ToList();
            var _pageNumbers = GetPages(_pages, _page, _pageNumbersCount);
            int _lastPageNumber = _pageNumbers?.LastOrDefault()?.Page ?? _pages;
            int _firstPageNumber = _pageNumbers?.FirstOrDefault()?.Page ?? 1;
    
            return new PagedObject<T>
            {
                PagedResults = _result,
                Pages = _pages,
                PageNumbers = _pageNumbers,
                Next = _page < _pages ? (1 + _page) : _pages,
                HasNext = _page < _pages,
                Previous = (_pages > 1 && _page > 1) ? (-1 + _page) : 1,
                HasPrevious = (_pages > 1 && _page > 1),
                Last = _pages,
                HasLast = _lastPageNumber < _pages,
                First = 1,
                HasFirst = _firstPageNumber > 1,
                Total = _itemCount
            };
        }
    
        private static List<PagedObjectPages> GetPages(int pages, int current, int pageNumbersCount)
        {
            var _pages = new List<PagedObjectPages>();
            if (pages > 1)
            {
                int firstHalfPageNumbersCount = pageNumbersCount / 2;
                int secondHalfPageNumbersCount = pageNumbersCount - firstHalfPageNumbersCount - 1;
    
                int _start = Math.Max(1, (current - firstHalfPageNumbersCount));
                int _last = Math.Min(pages, (current + secondHalfPageNumbersCount));
    
                _start = Math.Max(1, (_start - (secondHalfPageNumbersCount - (_last - current))));
    
                for (int i = _start; i <= pages && _pages.Count < pageNumbersCount; i++)
                    _pages.Add(new PagedObjectPages { Page = i, IsCurrent = current == i ? true : false });
            }
    
            return _pages;
        }
    
        public class PagedObjectPages
        {
            public bool IsCurrent { get; set; }
            public int Page { get; set; }
        }
    
        public class PagedObject<T>
        {
            public bool HasNext { get; set; }
            public bool HasPrevious { get; set; }
            public int Next { get; set; }
            public IEnumerable<T> PagedResults { get; set; }
            public List<PagedObjectPages> PageNumbers { get; set; }
            public int Pages { get; set; }
            public int Previous { get; set; }
            public int Total { get; set; }
            public int Last { get; set; }
            public int First { get; set; }
            public bool HasFirst { get; set; }
            public bool HasLast { get; set; }
        }
    }
