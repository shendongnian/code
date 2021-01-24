    using System;
    namespace DL.SO.Framework.Mvc.Pagination
    {
        public class Pager
        {
            // Here I hard code the page size but you can set it as one of
            // the parameters of its constructor
            private const int PAGESIZE = 12;
            public int TotalItems { get; private set; }
            public int CurrentPage { get; private set; }
            public int TotalPages { get; private set; }
            public int StartPage { get; private set; }
            public int EndPage { get; private set; }
            public int PageSize
            {
                get { return PAGESIZE; }
            }
            public int ShowingRangeFromItem
            {
                get
                {
                    int fromItem = (CurrentPage - 1) * PageSize + 1;
                    if (fromItem > TotalItems)
                    {
                       fromItem = TotalItems;
                    }
                    return fromItem;
                }
            }
            public int ShowingRangeToItem
            {
                get
                {
                    int toItem = CurrentPage * PageSize;
                    if (toItem > TotalItems)
                    {
                        toItem = TotalItems;
                    }
                    return toItem;
                }
            }
            // Constructor
            public Pager(int totalItems, int currentPage = 1)
            {
                // Calculate total, start and end pages
                var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)PageSize);
                currentPage = currentPage < 1
                    ? 1
                    : currentPage;
                // I only want to display +/- 2 pagination links
                var startPage = currentPage - 2;
                var endPage = currentPage + 2;
                if (startPage <= 0)
                {
                    endPage = endPage - startPage + 1;
                    startPage = 1;
                }
                if (endPage > totalPages)
                {
                    endPage = totalPages;
                    if (endPage > 5)
                    {
                        startPage = endPage - 4;
                    }
                }
                TotalItems = totalItems;
                CurrentPage = currentPage;
                TotalPages = totalPages;
                StartPage = startPage;
                EndPage = endPage;
            }
        }
    }
