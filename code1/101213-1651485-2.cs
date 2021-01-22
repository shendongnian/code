    public ActionResult Search(string q)
    {
        if (Validate(q))
        {
            string resultsUrl = Url.Action("Results", new { q = q });
            return View("ResultsLoading", new ResultsLoadingModel(resultsUrl));
        }
        else
        {
            return ShowSearchForm(...);
        }
    }
    bool Validate(string q)
    {
        // Validate
    }
    public ActionResult Results(string q)
    {
        if (Validate(q))
        {
            // Do Search and return View
        }
        else
        {
            return ShowSearchForm(...);
        }
    }
