     private async void expand()
        {
            var NewWindow = CoreApplication.CreateNewView();
            int Windowid = ApplicationView.GetForCurrentView().Id;
            int NewWindowid = 0;
            await NewWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame newframe = new Frame();
                newframe.Navigate(typeof(Newpage), null);
                Window.Current.Content = newframe;
                Window.Current.Activate();
                ApplicationView.GetForCurrentView().Title = "New Page";
                NewWindowid = ApplicationView.GetForCurrentView().Id;
            });
  
            //Call ProjectionManager class for moving new window to secodary display
            bool available = ProjectionManager.ProjectionDisplayAvailable;
            ProjectionManager.ProjectionDisplayAvailableChanged += (s, e) =>
            {
                available = ProjectionManager.ProjectionDisplayAvailable;
            };
            await ProjectionManager.StartProjectingAsync(NewWindowid, Windowid);
        }
