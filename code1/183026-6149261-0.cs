    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="true" >
    </asp:GridView>
    private static Random _rnd = new Random(DateTime.Now.Millisecond);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var columns = _rnd.Next(3, 10);
            var data = new { list = Enumerable.Range(1, columns).ToList() };
            GridView1.DataSource = data.list.Pivot();
            GridView1.DataBind();
        }
    }
    public static class Extensions
    {
        public static DataTable Pivot<T>(this IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            DataTable result = new DataTable();
            for (int index = 0; index < list.Count(); index++)
            {
                DataColumn column = new DataColumn(string.Format("Column{0}", index), typeof(T));
                result.Columns.Add(column);
            }
            var dataRow = result.NewRow().ItemArray = list.Select(item => (object)item).ToArray();
            result.Rows.Add(dataRow);
            return result;
        }
    }
