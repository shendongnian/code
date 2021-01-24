    [HttpGet("search/{option?}/{search}")]
    public  IActionResult GetSearchData(string option, string search, int? page, string currentFilter)
    {
        if (search != null)
        {
            page = 1;
        }
        else
        {
            search = currentFilter;
        }
        SearchViewModel data = new SearchViewModel();
        int pageSize = 10;
        IEnumerable<SearchDataItemViewModel> searchArticle = Mapper.Map<IEnumerable<SearchDataItemViewModel>>(_unitOfWork.Articles.GetByString(search));
            var searchArticleP = Helpers.PaginatedList<SearchDataItemViewModel>.CreateAsync(searchArticle, page ?? 1, pageSize);
            data.SearchArticle = searchArticleP;
        IEnumerable<SearchDataItemViewModel> searchArticle2 = Mapper.Map<IEnumerable<SearchDataItemViewModel>>(_unitOfWork.Articles2.GetByString(search));
            var searchArticleP2 = Helpers.PaginatedList<SearchDataItemViewModel>.CreateAsync(searchArticle2, page ?? 1, pageSize);
            data.SearchArticle2 = searchArticleP2;
        return View("Search", data));
    }
