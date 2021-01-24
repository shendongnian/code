    public class NavigationService : INavigationService
    {
        public void NavigateTo(Type viewType)
        {
            var rootFrame = Window.Current.Content as Frame;
            var homePage = rootFrame.Content as HomePage;
            homePage.NavigationFrame.Navigate(viewType);
        }
    
        public void NavigateBack()
        {
            var rootFrame = Window.Current.Content as Frame;
            var homePage = rootFrame.Content as HomePage;
            homePage.NavigationFrame.GoBack();
        }
    }
