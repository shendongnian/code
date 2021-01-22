     private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
     {
            PresentationPage currentPresentationPage = new PresentationPage();
            (App.Current.RootVisual as Panel).Children.Clear();
            (App.Current.RootVisual as Panel).Children.Add(currentPresentationPage);
            App.Current.Host.Content.IsFullScreen = true;
     }
