    [HttpPost]
    public InfluencerSearchResultWithFacets Post([FromUri]string q, [FromUri]string group, [FromBody]List<string> subGroups)
    {
       return GetSearchResult("",null,null);
    }
