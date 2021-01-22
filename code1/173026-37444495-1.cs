     void GetIPExternalAddress()
     {
                Task.Factory.StartNew(() =>
                {
                    var ipAddress = SystemHelper.GetExternalIPAddress();
    
                    Action bindData = () =>
                    {
                        if (!string.IsNullOrEmpty(ipAddress))
                            labelMainContent.Content = "IP External: " + ipAddress;
                        else
                            labelMainContent.Content = "IP External: ";
    
                        labelMainContent.Visibility = Visibility.Visible; 
                    };
                    this.Dispatcher.InvokeAsync(bindData);
                });
     
     }
