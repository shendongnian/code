    public class NavigationService
    {
        TypeMapperService mapperService { get; }
    
        public NavigationService(TypeMapperService mapperService)
        {
            this.mapperService = mapperService;
        }
    
        protected Page CreatePage(Type viewModelType)
        {
            Type pageType = mapperService.MapViewModelToView(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }
    
            return Activator.CreateInstance(pageType) as Page;
        }
    
        protected Page GetCurrentPage()
        {
            var mainPage = Application.Current.MainPage;
    
            if (mainPage is MasterDetailPage)
            {
                return ((MasterDetailPage)mainPage).Detail;
            }
    
            // TabbedPage : MultiPage<Page>
            // CarouselPage : MultiPage<ContentPage>
            if (mainPage is TabbedPage || mainPage is CarouselPage)
            {
                return ((MultiPage<Page>)mainPage).CurrentPage;
            }
    
            return mainPage;
        }
    
        public Task PushAsync(Page page, bool animated = true)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            return navigationPage.PushAsync(page, animated);
        }
    
        public Task PopAsync(bool animated = true)
        {
            var mainPage = Application.Current.MainPage as NavigationPage;
            return mainPage.Navigation.PopAsync(animated);
        }
    
        public Task PushModalAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel =>
            InternalPushModalAsync(typeof(TViewModel), animated, parameter);
    
        public Task PopModalAsync(bool animated = true)
        {
            var mainPage = GetCurrentPage();
            if (mainPage != null)
                return mainPage.Navigation.PopModalAsync(animated);
    
            throw new Exception("Current page is null.");
        }
    
        async Task InternalPushModalAsync(Type viewModelType, bool animated, object parameter)
        {
            var page = CreatePage(viewModelType);
            var currentNavigationPage = GetCurrentPage();
    
            if (currentNavigationPage != null)
            {
                await currentNavigationPage.Navigation.PushModalAsync(page, animated);
            }
            else
            {
                throw new Exception("Current page is null.");
            }
    
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }
    }
