    interface IGridSearch
    {
        void PerformSearch(string criteria);
    }
    
    public partial class MdiChildUI : Form, IGridSearch
    {
        public MdiChildUI()
        {
            InitializeComponent();
        }
    
        public void PerformSearch(string criteria)
        {
            // peform the search
        }        
    }
    
    public partial class MdiParentUI : Form
    {
        public MdiParentUI()
        {
            InitializeComponent();
        }
    
        private void MdiParentUI_MdiChildActivate(object sender, EventArgs e)
        {
            SetControlStates();
    
        }
    
        private void SetControlStates()
        {
            _searchCommand.Enabled = (this.ActiveMdiChild is IGridSearch);
        }
    
        private void _searchCommand_Click(object sender, EventArgs e)
        {
            IGridSearch child = (this.ActiveMdiChild as IGridSearch);
            if (child != null)
            {
                child.PerformSearch("whatever to search for");
            }
            else
            {
                MessageBox.Show("Can't search in the active form");
            }
        }
    }
