    public partial class UsersTableAdapter : ITableAdapter<FileParkDataSet.UsersDataTable>
    {
        #region ITableAdapter<UsersDataTable> Members
        public void AttachTransaction(SqlTransaction _transaction)
        {
            if (this.Adapter == null)
                this.InitAdapter();
            this.Adapter.InsertCommand.Transaction = _transaction;
            this.Adapter.UpdateCommand.Transaction = _transaction;
            this.Adapter.DeleteCommand.Transaction = _transaction;
            foreach (var _cmd in this.CommandCollection)
            {
                _cmd.Transaction = _transaction;
            }
        }
        public SqlTransaction CreateTransaction()
        {
            if (this.Connection.State != ConnectionState.Closed)
                this.Connection.Close();
            this.Connection.Open();
            return this.Connection.BeginTransaction();
        }
        #endregion
    }
