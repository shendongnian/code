    public static class PageExtensions
    {
        public string GetMyValue(this Page page, BindableProperty headerTextProperty)
        {
            return (string)page.GetValue(headerTextProperty);
        }
        public void SetMyValue(this Page page, out BindableProperty headerTextProperty, string value)
        {
            headerTextProperty = null;
            headerTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(SearchPage), value);
            page.OnPropertyChanged("HeaderText");
        }
    }
    public class MyMasterContentPage : ContentPage
    {
        // ...
        public BindableProperty HeaderTextProperty;
        public string HeaderText
        {
            get { return GetMyValue(HeaderTextProperty); }
            set
            {
                SetMyValue(out HeaderTextProperty, value);
            }
        }
    }
    public class MyContentPage : MyMasterContentPage, INotifyPropertyChanged
    {
    }
    public class MyMasterCarouselPage : ContentPage
    {
        // ...
        public BindableProperty HeaderTextProperty;
        public string HeaderText
        {
            get { return GetMyValue(HeaderTextProperty); }
            set
            {
                SetMyValue(out HeaderTextProperty, value);
            }
        }
    }
    public class MyCarouselPage : MyMasterCarouselPage, INotifyPropertyChanged
    {
    }
