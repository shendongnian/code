    ConnectionSearch connectionSearch;
    string searchPhrase;
    public string SearchPhrase
    {
        get => searchPhrase;
        set
        {
            //do your setter work
            if(connectionSearch != null)
            {
                connectionSearch.Cancel();
            }
            connectionSearch = new ConnectionSearch(value, addConnectionUser);
            connectionSearch.PerformSearch();
        }
    }
    
    void addConnectionUser(object uc)
    {
        //pperform your add logic.. 
    }
