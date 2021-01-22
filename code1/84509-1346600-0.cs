    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public int ColumnCount
        { 
            get
            {
                return this.tableLayoutPanel1.ColumnCount;
            }
            set
            {
                this.tableLayoutPanel1.ColumnCount = value;
            }
        }
    }
