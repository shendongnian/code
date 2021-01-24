    if (e.PrelaunchActivated == false)
    {
      if (rootFrame.Content == null)
      {
      // When the navigation stack isn't restored navigate to the first page,
      // configuring the new page by passing required information as a navigation
      // parameter
        if (e.TileId == "xxxxxx")
        {
          //Do what you want to do here
          //Then navigate to a specific page
          rootFrame.Navigate(typeof(AlternatePage));
        }
        else
        {
          rootFrame.Navigate(typeof(MainPage), e.TileId);
        }
      }
      // Ensure the current window is active
      Window.Current.Activate();
    }
 
