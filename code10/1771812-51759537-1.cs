    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            Validation validation = new Validation();
            // since you know that the text will be focused when the validation fails
            var result1 = validation.validate(ref txtName);
            var result2 = validation.validate(ref txtAge);
            MyExpander.IsExpanded = !result1 || !result2;
            if(result1 && result2)
            {
               //Do Something.
            }
        }
    }
