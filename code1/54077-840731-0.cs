    class SearchServiceProxy : ClientBase<ISearchService>, ISearchService
    {
    	public string GetName()
    	{
    		return Channel.GetName();
    	}
    }
