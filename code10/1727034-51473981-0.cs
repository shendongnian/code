    public partial class CComboBox : ComboBox
    {
        private bool savedAutoClose;
        public CComboBox()
        {
            InitializeComponent();
        }
        protected override void OnDropDownClosed(EventArgs e)
        {
            if (this.Parent != null)
            {
                var dropDownHost = this.Parent.Parent as ToolStripDropDown; // recursive instead?
                if (dropDownHost != null)
                    dropDownHost.AutoClose = savedAutoClose; // restore the parent's AutoClose preference
            }
            base.OnDropDownClosed(e);
        }
        protected override void OnDropDown(EventArgs e)
        {
            if (this.Parent != null)
            {
                var dropDownHost = this.Parent.Parent as ToolStripDropDown; // recursive instead?
                if (dropDownHost != null)
                {
                    savedAutoClose = dropDownHost.AutoClose;
                    // ensure that our parent doesn't close while the calendar is open
                    dropDownHost.AutoClose = false;
                }
            }
            base.OnDropDown(e);
        }
    }
