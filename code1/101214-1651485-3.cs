    static string SearchLoadingPageSentKey = "Look at me, I'm a magic string!";
    public ActionResult Search(string q)
    {
        if (Validate(q))
        {
            if (TempData[SearchLoadingPageSentKey]==null)
            {
                TempData[SearchLoadingPageSentKey] = true;
                string resultsUrl = Url.Action("Search", new { q = q });
                return View("ResultsLoading", new ResultsLoadingModel(resultsUrl));
            }
            else
            {
                // Do actual search here
                return View("SearchResults", model);
            }
        }
        else
        {
            return ShowSearchForm(...);
        }
    }
