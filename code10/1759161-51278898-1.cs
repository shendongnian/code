    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        public ViewModel ViewModel { get; } = new ViewModel();
    }
        <ListView ItemsSource="{x:Bind ViewModel.ImageThumbnailList}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ImageThumbnail">
                    <Grid>
                        <Image Source="{x:Bind ImageSource}" />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
