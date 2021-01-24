    [HttpPost]
    public ActionResult searchWithDropsAj(string term, string searchType)
    {
        var productSearch = new List<movieTbl>();
        if (searchType == "conSearch")
        {
          // your existing code to get data
        }
        // your existing code to get data       
        
        return PartialView(productSearch);
    }
