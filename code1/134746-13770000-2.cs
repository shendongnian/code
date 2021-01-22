    private static IEnumerable<T> PagedIterator<T>(IEnumerable<T> objectList, int PageSize)
    {
        var page = 0;
        var recordCount = objectList.Count();
        var pageCount = (int)((recordCount + PageSize)/PageSize);
        if(pageCount < 2)
        {
            return objectList;
        }
            
        while (page < pageCount)
        {
            var pageData = objectList.Skip(PageSize*page).Take(PageSize).ToList();
            foreach (var rd in pageData)
            {
                yield return rd;
            }
            page++;
        }
    }
