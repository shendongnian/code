    public partial class MainPage : TabbedPage
        {
            public static ObservableCollection<NameObject> NameList = new ObservableCollection<NameObject>();
            
            public MainPage()
            {
                InitializeComponent();
                NameList = new ObservableCollection<NameObject>();
                Methods.FillNameDictionary();
                BindingContext = this;
            }
        }
