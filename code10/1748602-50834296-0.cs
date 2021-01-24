     public partial class MainWindow : Window
        {
           
            public MainWindow()
            {
                InitializeComponent();
                this.Loaded += MainWindow_Loaded;
    
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                TextBlock textBlockInTemplate = (TextBlock)btn.Template.FindName("textblock1", btn);
                textBlockInTemplate.Text = "SampleText2";
            }
           
        } 
  
