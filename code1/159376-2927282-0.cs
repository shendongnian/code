    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            foreach (var page in _tabControl.TabPages.Cast<TabPage>())
            {
                page.CausesValidation = true;
                page.Validating += new CancelEventHandler(OnTabPageValidating);
            }
        }
        void OnTabPageValidating(object sender, CancelEventArgs e)
        {
            TabPage page = sender as TabPage;
            if (page == null)
                return;
            if (/* some validation fails */)
                e.Cancel = true;
        }
    }
