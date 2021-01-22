    public Pagination GetCategoryPaging(int currentPage, int recordCount, string query)
    {
        string pageClass = string.Empty; int pageSize = 10, innerCount = 5;
        Pagination pagination = new Pagination();
        pagination.Pages = new List<PageEntity>();
        pagination.Next = currentPage + 1;
        pagination.Previous = ((currentPage - 1) > 0) ? (currentPage - 1) : 1;
        pagination.Query = query;
        int totalPages = ((int)recordCount % pageSize) == 0 ? (int)recordCount / pageSize : (int)recordCount / pageSize + 1;
        int loopStart = 1, loopCount = 1;
        if ((currentPage - 2) > 0)
        {
            loopStart = (currentPage - 2);
        }
        for (int i = loopStart; i <= totalPages; i++)
        {
            pagination.Pages.Add(new PageEntity { Page = i, Class = string.Empty });
            if (loopCount == innerCount)
            { break; }
            loopCount++;
        }
        if (totalPages <= innerCount)
        {
            pagination.PreviousClass = "disabled";
        }
        foreach (var item in pagination.Pages.Where(x => x.Page == currentPage))
        {
            item.Class = "active";
        }
        if (pagination.Pages.Count() <= 1)
        {
            pagination.Display = false;
        }
        return pagination;
    }
