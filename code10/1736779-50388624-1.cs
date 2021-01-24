    Label userNameLabel = (Label)this.FindControl("userfullname");
    var userName = userNameLabelText;
    var notificationList = NotificationService.GetNotificationData(userName);
    foreach(var notification in notificationList)
    {
        var modulename = notification.ModuleName;
        var notifcount = notification.Count;
        string modulebody = modulename + "Body";
        string moduleLabel = modulename + "Label";
        
        Label namebox = (Label)this.FindControl(modulename);
        if (notifcount > 0)
        {
            namebox.Visible = true;
            namebox.Text = notifcount.ToString();
            this.FindControl(modulebody).Visible = true;
            try
            {
                this.FindControl(moduleLabel).Visible = true;
            }
            catch
            {
                notifLabel.Visible = false;
            }
        }
        else
        {
            namebox.Visible = false;
            this.FindControl(modulebody).Visible = false;
            try
            {
                this.FindControl(moduleLabel).Visible = false;
            }
            catch
            {
                notifLabel.Visible = false;
            }
        }
    }
