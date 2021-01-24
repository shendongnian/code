    private async void newpage()
    {
        int NewWindowid = 0;
        int Windowid = ApplicationView.GetForCurrentView().Id;
        CoreApplicationView newView = CoreApplication.CreateNewView();
        await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            Frame newframe = new Frame();
            newframe.Navigate(typeof(OtherPage), this); // this means existing MainPage object.
            Window.Current.Content = newframe;
            Window.Current.Activate();
            NewWindowid = ApplicationView.GetForCurrentView().Id;
        });
    
        bool available = ProjectionManager.ProjectionDisplayAvailable;
    
        ProjectionManager.ProjectionDisplayAvailableChanged += (s, e) =>
        {
            available = ProjectionManager.ProjectionDisplayAvailable;
        };
    
        await ProjectionManager.StartProjectingAsync(NewWindowid, Windowid);
        SubMessage();
    }
    private void SubMessage()
    {
        MessagingCenter.Subscribe<OtherPage, string>(this, "Tag", async (s, arg) =>
        {
           await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                textblock.Text = arg;
            });
    
        });
    }
