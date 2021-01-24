    public sealed partial class MainPage : Page
    {
        private void HamburgerMenuMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Other options similar ...
            else if (HamburgerMenuItemSave.IsSelected)
            {
                // 1. Check if the current page is the correct type
                if (MyFrame.Content is WorkingPage workingPage)
                {
                    // 2. Grab the data to pass from the instance of the displayed page
                    MyClass dataToPass = workingPage.myClass;
                    // 3. Pass the grabbed data to the page being navigated to
                    MyFrame.Navigate(typeof(Pages.File.SavePage), dataToPass);
                }
            }
            // Other options similar ...
        }
    }
