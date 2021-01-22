    public partial class MyTableAdapter
    {
        public MyTableAdapter(SqlConnection connection)
        {
            this._connection = connection;
            this.ClearBeforeFill = true;
        }
    }
