    public class PagingHelper
    {
        public IEnumerable<int> GetListOfPages(int currentPage, int pagesAroundCurrent, int totalPages)
        {
            var pages = new Dictionary<int, int>();
            double powerOfTenTotalPages = Math.Floor(Math.Log10(totalPages));
            if ((int)powerOfTenTotalPages == 0)
            {
                powerOfTenTotalPages = 1;
            }
            pages.Add(1, 1);
            if (!pages.ContainsKey(totalPages))
            {
                pages.Add(totalPages, totalPages);
            }
            for (int loop = 1; loop <= powerOfTenTotalPages + 1; loop++)
            {
                GetPages(pages, currentPage, pagesAroundCurrent, totalPages, (int)Math.Pow(10, loop - 1));
            }
            return pages.OrderBy(k=>k.Key).Select(p=>p.Key).AsEnumerable();
        }
        private void GetPages(Dictionary<int, int> pages, int currentPage, int pagesAroundCurrent, int totalPages, int jump)
        {
            int startPage = ((currentPage / jump) * jump) - (pagesAroundCurrent * jump);
            if (startPage < 0)
            {
                startPage = 0;
                pagesAroundCurrent = 10;
            }
            int endPage = currentPage + (pagesAroundCurrent * jump);
            if (endPage > totalPages)
            {
                endPage = totalPages;
            }
            AddPagesToDict(pages, startPage, endPage, jump);
        }
        private void AddPagesToDict(Dictionary<int, int> pages, int start, int end, int jump)
        {
            for (int loop = start; loop <= end; loop += jump)
            {
                if (!pages.ContainsKey(loop))
                {
                    if (loop > 0)
                    {
                        pages.Add(loop, loop);
                    }
                }
            }
        }
    }
