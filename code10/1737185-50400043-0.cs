    using Windows.UI.Notifications;
    using Microsoft.Toolkit.Uwp.Notifications;
     
    public void SendUpdatableToastWithProgress()
    {
        // Define a tag (and optionally a group) to uniquely identify the notification, in order update the notification data later;
        string tag = "weekly-playlist";
        string group = "downloads";
     
        // Construct the toast content with data bound fields
        var content = new ToastContent()
        {
            Visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "Downloading your weekly playlist..."
                        },
        
                        new AdaptiveProgressBar()
                        {
                            Title = "Weekly playlist",
                            Value = new BindableProgressBarValue("progressValue"),
                            ValueStringOverride = new BindableString("progressValueString"),
                            Status = new BindableString("progressStatus")
                        }
                    }
                }
            }
        };
     
        // Generate the toast notification
        var toast = new ToastNotification(content.GetXml());
     
        // Assign the tag and group
        toast.Tag = tag;
        toast.Group = group;
     
        // Assign initial NotificationData values
        // Values must be of type string
        toast.Data = new NotificationData();
        toast.Data.Values["progressValue"] = "0.6";
        toast.Data.Values["progressValueString"] = "15/26 songs";
        toast.Data.Values["progressStatus"] = "Downloading...";
     
        // Provide sequence number to prevent out-of-order updates, or assign 0 to indicate "always update"
        toast.Data.SequenceNumber = 1;
     
        // Show the toast notification to the user
        ToastNotificationManager.CreateToastNotifier().Show(toast);
    }
