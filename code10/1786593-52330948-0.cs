    private void MouseEvent_Click(object sender, EventArgs args)
    {
        await LoadCustomers();
    }
    public async Task LoadCustomers()
    {
        // Update UI to show spinner
        this.LoadingCustomers = true;
      
        // We don't need Device.BeginInvokeOnMainThread, because await automatically 
        // goes back to calling thread when it is finished
        var customers = await this.custService.GetCustomers();
        this.LoadingCustomers = false;
    }
