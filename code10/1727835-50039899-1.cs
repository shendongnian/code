    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<Test> ls = new List<Test>();
            List<MyMenuItem> myMenuItems = new List<MyMenuItem>();
            myMenuItems.Add(new MyMenuItem() {Text="menu1" });
            myMenuItems.Add(new MyMenuItem() {Text="menu2" });
            ls.Add(new Test() {item="item1",menuItems=myMenuItems });
            ls.Add(new Test() { item = "item2", menuItems = myMenuItems });
            gridview.ItemsSource = ls;
        }
    }
    public class Test:ViewModelBase
    {
        public string item { get; set; }
        public List<MyMenuItem> menuItems { get; set; }
        public RelayCommand<object> relayCommand { get; set; }
        public Test()
        {
            relayCommand = new RelayCommand<object>(ShowFlyout);
        }
        private void ShowFlyout(object obj)
        {
            FrameworkElement senderElement = obj as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }
    }
    public class MyMenuItem
    {
        public string Text { get; set; }
    }
