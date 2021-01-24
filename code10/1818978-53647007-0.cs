    private Timer timer = null;
    private DateTime lastCalledCreateRenewalNotifications = DateTime.MinValue;
    NotificationManager.ProcessApprovalNotifications();
    if (DateTime.Now - lastCalledCreateRenewalNotifications >= TimeSpan.FromDays(1))
    {
        NotificationManager.CreateRenewalNotifications();
        lastCalledCreateRenewalNotifications = DateTime.Now;
    }
    NotificationManager.ProcessRenewalNotifications();
