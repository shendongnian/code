    //ViewModel class
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    <!--View XAML-->
    <TextBox x:Name="txt_username" Text="{Binding Username}" />
    <TextBox x:Name="txt_password" Text="{Binding Password}" />
