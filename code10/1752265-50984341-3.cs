    public async Task LoadDataAsync()
    {
        Notifications = new ObservableCollection<MailingDeliveryNotification>(
            await context.MailingDeliveryNotifications.ToListAsync());
        Customers = new ObservableCollection<Customer>(
            await context.Customers.ToListAsync());
    }
