    public sealed partial class MainPage : Page
    {
        ObservableCollection<DBOPTION> Items;
        public MainPage()
        {
            this.InitializeComponent();
            Items = new ObservableCollection<DBOPTION>()
            {
                new DBOPTION()
                {
                   _id=1,LABEL="test1",IS_CORRECT=1,QUESTION_ID=3
                },
                 new DBOPTION()
                {
                    _id=1,LABEL="test1",IS_CORRECT=1,QUESTION_ID=3
                },
                  new DBOPTION()
                {
                     _id=1,LABEL="test1",IS_CORRECT=1,QUESTION_ID=3
                }
            };
            Binding myBinding = new Binding();
            myBinding.Source = Items;
            ListOption.SetBinding(ItemsControl.ItemsSourceProperty, myBinding);
        }
        private void ListAlternatives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
    public class DBOPTION
    {
        public int _id { get; set; }
        public string LABEL { get; set; }
        public int IS_CORRECT { get; set; }
        public int QUESTION_ID { get; set; }
     
     }
    class MyProperties
    {
        // "HtmlString" attached property for a WebView
        public static readonly DependencyProperty HtmlStringProperty =
           DependencyProperty.RegisterAttached("HtmlString", typeof(string), typeof(MyProperties), new PropertyMetadata("", OnHtmlStringChanged));
        // Getter and Setter
        public static string GetHtmlString(DependencyObject obj) { return (string)obj.GetValue(HtmlStringProperty); }
        public static void SetHtmlString(DependencyObject obj, string value) { obj.SetValue(HtmlStringProperty, value); }
        // Handler for property changes in the DataContext : set the WebView
        private static void OnHtmlStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebView wv = d as WebView;
            if (wv != null)
            {
                wv.NavigateToString((string)e.NewValue);
            }
        }
    }
