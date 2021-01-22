    public partial class MyTableAdapter
    {
        public MyTableAdapter(SqlConnection connection)
        {
            thisSetConnection(connection);
            this.ClearBeforeFill = true;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
