    [DefaultProperty("ColumnCount")]
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        [Description("Gets or sets the column count of the table layout.")]
        [Category("TableLayout")]
        [DefaultValue(2)]
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
