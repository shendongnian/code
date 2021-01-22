    public partial class _Default : System.Web.UI.Page
    {
        private readonly DataTable _dataTable;
        public _Default()
        {
            _dataTable = new DataTable();
            _dataTable.Columns.Add("Serial", typeof (int));
            _dataTable.Columns.Add("Data", typeof (string));
            for (var i = 0; ++i <= 15;) 
            _dataTable.Rows.Add(new object[] {i, "This is row " + i});
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }
        private void BindData()
        {
            gvTest.DataSource = _dataTable;
            gvTest.DataBind();
        }
        protected void btnUpdateClick(object sender, EventArgs e)
        {
            if (gvTest.SelectedIndex < 0) return;
            var r = gvTest.SelectedRow;
            var i = r.DataItemIndex;
            
            //you can get primary key or anyother column vlaue by 
            //accessing r.Cells collection, but for this simple case
            //we will use index of selected row in database.
            _dataTable.Rows.RemoveAt(i);
            //rebind with data
            BindData();
            //clear selection from grid
            gvTest.SelectedIndex = -1;
        }
    }
