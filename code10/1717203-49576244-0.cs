    public partial class YourPage : ContentPage
    {
        LoginModel loginModel = new LoginModel();
        public YourPage()
        {
            BindingContext = loginModel
        }
    }
