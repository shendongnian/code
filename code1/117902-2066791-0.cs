    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            // THIS IS THE LINE THATS IMPORTANT
            pLine.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
       }
    }
