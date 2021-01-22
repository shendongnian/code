    public partial class Window3 : Window
    {
        bool _allowed { get; set; }
        public Window3( bool allowed)
        {
            _allowed = allowed;
            InitializeComponent();
        }
    
        public void ShowDialog()
        {
            if( !_allowed)
                return;
            else
                base.ShowDialog();
        }
    }
