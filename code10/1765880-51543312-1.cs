    public static class PageExtensions
    {
        public string GetMyValue(this Page page, BindableProperty headerTextProperty)
        {
            return (string)page.GetValue(headerTextProperty);
        }
        public void SetMyValue(this Page page, out BindableProperty headerTextProperty, string value)
        {
            headerTextProperty = null;
            if (page is INotifyPropertyChanged notifyPage)
            {
                headerTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(SearchPage), value);
                notifyPage.OnPropertyChanged("HeaderText");
            }
        }
    }
    public class MyMasterContentPage : ContentPage
    {
        // ...
        public BindableProperty HeaderTextProperty;
        public string HeaderText
        {
            get { return GetMyValue(HeaderTextProperty); }
            set { SetMyValue(out HeaderTextProperty, value); }
        }
    }
    public class MyContentPage : MyMasterContentPage, INotifyPropertyChanged
    {
    }
    public class MyMasterCarouselPage : CarouselPage
    {
        // ...
        public BindableProperty HeaderTextProperty;
        public string HeaderText
        {
            get { return GetMyValue(HeaderTextProperty); }
            set { SetMyValue(out HeaderTextProperty, value); }
        }
    }
    public class MyCarouselPage : MyMasterCarouselPage, INotifyPropertyChanged
    {
    }
