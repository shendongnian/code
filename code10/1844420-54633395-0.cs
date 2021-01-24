    public partial class Page1:ContentPage
    {
        User _user;
        public Page1 (User user)
        {
            InitializeComponent ();
            BindingContext = _user = user;
        }
    }
