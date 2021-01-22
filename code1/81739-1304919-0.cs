    public partial class FunctionButton : UserControl
    {
        public FunctionButton()
        {
            InitializeComponent();
        }
    
        private void MenuItem_Click(object sender, EventArgs e)
        {
            PerformCommand();            
        }
    
        private void Button_Click(object sender, EventArgs e)
        {
            PerformCommand();
        }
    
        private void PerformCommand()
        {
            OnClick(EventArgs.Empty);
        }
    
        public Keys ShortcutKeys
        {
            get
            {
                return _menuItem.ShortcutKeys;
            }
            set
            {
                _menuItem.ShortcutKeys = value;
            }
        }
    }
