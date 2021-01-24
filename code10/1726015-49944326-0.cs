    public partial class UserPostView : ContentView
    {
        public UserPostView()
        {
            InitializeComponent();
        }
    }
    //NOTE: in UserPostView.xaml 
    <Image Source="{Binding Picture}" BackgroundColor="#ddd" />
    <Label Text="{Binding PostOwner}" TextColor="#444" FontAttributes="Bold" Margin="10" />
    <Label Text="{Binding PostOwnerLocation}" TextColor="#666" YAlign="Center" />
    ...
