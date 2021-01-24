    using Windows.UI.Notifications;
     
    public void UpdateProgress()
    {
        // Construct a NotificationData object;
        string tag = "weekly-playlist";
        string group = "downloads";
     
        // Create NotificationData and make sure the sequence number is incremented
        // since last update, or assign 0 for updating regardless of order
        var data = new NotificationData
        {
            SequenceNumber = 2
        };
    
        // Assign new values
        // Note that you only need to assign values that changed. In this example
        // we don't assign progressStatus since we don't need to change it
        data.Values["progressValue"] = "0.7";
        data.Values["progressValueString"] = "18/26 songs";
    
        // Update the existing notification's data by using tag/group
        ToastNotificationManager.CreateToastNotifier().Update(data, tag, group);
    }
