    public TimelinePage()
    {
        InitializeComponent();
        ImageSource pic = ImageSource.FromUri(new Uri("https://tse1.mm.bing.net/th?id=OIP.acchQ02P8HmrmwbjCTwG5AHaHa&pid=Api"));
        _listView.ItemsSource = new ObservableCollection<UserPostViewModel>
        {
            new UserPostViewModel { Picture = ImageSource.FromResource("Logo"), PostOwner="Kevin Wang", PostOwnerLocation="SHDR"},
            new UserPostViewModel { Picture = pic, PostOwner="Lily", PostOwnerLocation="SHDR"},
            new UserPostViewModel { Picture = pic, PostOwner="Zhang Shuo", PostOwnerLocation="FRDL"},
        };
    }
    //NOTE: In your Pages ListView DataTemplate
    <ListView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <local:UserPostView/>
            </ViewCell>
        </DataTemplate>
    </ListView.ItemTemplate>
