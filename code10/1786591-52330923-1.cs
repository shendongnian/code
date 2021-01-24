    public async Task LoadCustomers()
    {
        // Update UI to show spinner
        this.LoadingCustomers = true;
        var customers = await this.custService.GetCustomers();
        // code truncated for clarity
        // you are still on UI thread here
        this.LoadingCustomers = false;
    }
