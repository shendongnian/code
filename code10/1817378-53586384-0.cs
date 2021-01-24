    public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
    {
        if (mode == NavigationMode.New || mode == NavigationMode.Refresh)
        {
            IsBusy = true;      //Show progress ring
            CreateServices();   //Create API service
    
            //Download binders for board and populate ObservableCollection<Binder>
            //This has a cover image and other info I want to show in the UI immediately 
            await PopulateBinders();
    
    	    await PouplateBoardData();
           
            await base.OnNavigatedToAsync(parameter, mode, state);
            return;          
        }
    }
    
    private async void PopulateBoardData()
    {
        await Task.WhenAll(new[]
        {
                PopulateBoardFiles(),
                PopulateBoardEvents()
        });               
    
        IsBusy = false;
    }
