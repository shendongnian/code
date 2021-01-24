    bool isBusy;
    public bool IsBusy
    {
        get => isBusy; 
        set 
        { 
            isBusy = value; 
            OnPropertyChanged(); 
        }
    }
    async Task LoadItemsAsync()
    {
        try
        {
            IsBusy = true;
            // Call your web service here
            var items = await service.LoadSomthingAsync();
        }
        catch (Exception ex)
        {
            // Handle exception
        }
        finally
        {
            IsBusy = false;
        }
    }
