    public partial class MainWindow : Window
    {
        public ViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            ViewModel = new ViewModel();
            this.DataContext = ViewModel;
        }
    }
    <Grid>
        <ListBox 
        HorizontalAlignment="Left"
        Height="100"
        Margin="334,132,0,0"
        VerticalAlignment="Top"
        Width="100"
        ItemsSource="{Binding SampleLines}"/>
        <TextBox
        HorizontalAlignment="Left" 
        Height="23"
        Margin="184,166,0,0" 
        TextWrapping="Wrap"
        VerticalAlignment="Top"
        Width="120"
        Text="{Binding OneLineOnly}"/>
    </Grid>
