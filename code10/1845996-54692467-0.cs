    public partial class View1 : UserControl
    {
        public View1()
        {
            InitializeComponent();
            Loaded += (s, e) => dataGrid1.Focus();
        }
    }
