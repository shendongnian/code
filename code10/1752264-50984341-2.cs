    public async Task LoadDataAsync()
    {
        await LoadNotificationsAsync();
        await LoadCustomersAsync();
    }
    private async Task LoadNotificationsAsync()
    {
        var res = await context.MailingDeliveryNotifications.ToListAsync();
        Notifications = new ObservableCollection<MailingDeliveryNotification>(res);
    }
    private async Task LoadCustomersAsync()
    {
        var res = await context.Customers.ToListAsync();
        Customers = new ObservableCollection<Customer>(res);
    }
