    public partial class Info
    {
        public Info()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                VisualState = ESecurePageVisualState.Blink;
            };
        }       
    }
