    public sealed partial class MainPage : Page
    {
        private string _IsAdmin;
        public string IsAdmin
        {
            get { return _IsAdmin; }
            set
            {
                if (value == string.Empty)
                {
                    _IsAdmin = null;
                }
                else
                {
                    _IsAdmin = value;
                }
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
            IsAdmin = string.Empty; ;
        }
    }
