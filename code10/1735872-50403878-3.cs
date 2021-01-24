    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
    
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder info = new StringBuilder();
            foreach (var item in ViewModel.Items )
            {
                info.AppendLine(item.Ingredient_name + "--------" + item.IsCheck.ToString());
            }
            InfoDisplay.Text = info.ToString();
        }
    }
