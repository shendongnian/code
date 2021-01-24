    public sealed partial class MainPage : Page
        {
            List<LineItem> MyDictionary = new List<LineItem>();
            public MainPage()
            {
                MyDictionary.Add(new LineItem() { Title = "Item1", description = "Desc1" });
                MyDictionary.Add(new LineItem() { Title = "Item2", description = "Desc2" });
                MyDictionary.Add(new LineItem() { Title = "Item3", description = "Desc3" });
                this.InitializeComponent();
                GridView.ItemsSource = MyDictionary;
            }
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                LineItem clicked_item  =(LineItem)((sender as FrameworkElement).DataContext);
                await (new MessageDialog(clicked_item.Title + " Button is clicked ")).ShowAsync();
            }
        }
        public class LineItem
        {
            public string Title { get; set; }
            public string description { get; set; }
        }
 
