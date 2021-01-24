    private async void LoadMoreEmployerResult()
    {
        IsBusy = true;
        if(EmployerResults.Last().Name == "")
    		EmployerResults.RemoveAt(EmployerResults.Count - 1);
    	List<EmployerProfile> currentPageList= await _employerApiClient.GetMoreData(pagenumber);
    	if(currentPageList.Count > 0)
    	{
    		EmployerResults.AddRange(currentPageList);
    		EmployerResults.Add(new EmployerProfile());
    	}
    	
        IsBusy = false;
    }
