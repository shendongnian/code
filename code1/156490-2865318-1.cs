    public partial class Window1 : Window
    {
        public Window1()
        {
            Users = new DataTable("users");
            Users.Columns.Add("username");
            Users.Rows.Add(CreateDataRow("Fred"));
            Users.Rows.Add(CreateDataRow("Bob"));
            Users.Rows.Add(CreateDataRow("Jim"));
            InitializeComponent();
            
            cmbEmail.DataContext = Users;
        }
        public DataTable Users { get; private set; }
        private DataRow CreateDataRow(string userName)
        {
            DataRow dr = Users.NewRow();
            dr["username"] = userName;
            return dr;
        }
    }
