    public class NavigationService : INavigationService
    {
        public void NavigateTo(Type viewType)
        {
            var homePage = Window.Current.Content as HomePage;
            homePage.NavigationFrame.Navigate(viewType);
        }
    
        public void NavigateBack()
        {
            var homePage = Window.Current.Content as HomePage;
            homePage.NavigationFrame.GoBack();
        }
    }
