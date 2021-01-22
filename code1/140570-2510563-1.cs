    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("col1", typeof(string));
            DataRow row;
            row = table.NewRow();
            row["col1"] = "123";
            table.Rows.Add(row);
            row = table.NewRow();
            row["col1"] = "456";
            table.Rows.Add(row);
            LinqList<DataRow> rows = new LinqList<DataRow>(table.Rows);
            // do a simple select
           DataRow [] selectedRows = (from r in rows where (string)r["col1"] == "123" select r).ToArray();
            if(selectedRows.Length > 0)
            {
                lable1.Text = "success";
            }
            else
            {
                lable1.Text = "failed";
            }
        }
    }
    // simple wrapper that implements IEnumerable<T>
    internal class LinqList<T> : IEnumerable<T>, IEnumerable
    {
        IEnumerable items;
        internal LinqList(IEnumerable items)
        {
            this.items = items;
        }
        #region IEnumerable<DataRow> Members
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T item in items)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerable<T> ie = this;
            return ie.GetEnumerator();
        }
        #endregion
    }
