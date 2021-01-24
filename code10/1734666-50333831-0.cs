    private DataView _list;
    public DataView List
    {
        get { return _list; }
        private set
        {
            _list = value;
        }
    }
    public TestViewModel()
    {
        DeleteButtonCommand = new DelegateCommand(somethingABC);
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StringConnexion"].ConnectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("Select * from dbo.users", connection);
            adapter.Fill(dt);
        }
        List = dt.DefaultView;
    }
    public void somethingABC()
    {
        List.Table.Rows.RemoveAt(0); //remove the first row
    }
