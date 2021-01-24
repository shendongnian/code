     public class CustomTabbedPage : TabbedPage
    {
        public static readonly BindableProperty TabNumberProperty = BindableProperty.Create(
                 nameof(TabNumber),
                 typeof(int),
                 typeof(CustomTabbedPage),
                 int.MinValue);
        private int _tabNumber;
        public int TabNumber
        {
            get { return _tabNumber; }
            set
            {
                _tabNumber = value;
                OnPropertyChanged();
            }
        }
        public void ChangeTabState( int tabNumber, bool isEnabled )
        {
        }
        public CustomTabbedPage()
        {
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
