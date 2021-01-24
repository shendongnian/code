        public partial class ZRoleEditUserControl : UserControl
    {
        public ZRoleEditUserControl(ZRoleEditViewModel context)
        {
            InitializeComponent();
            this.DataContext = context;
        }
    }
