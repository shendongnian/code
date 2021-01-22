    public interface ITableAdapter<TDataTable> : IDisposable
        where TDataTable : DataTable
    {
        void AttachTransaction(SqlTransaction _transaction);
        SqlTransaction CreateTransaction();
        int Update(TDataTable _dataTable);
        TDataTable GetData();
        TDataTable GetById(int Id);
    }
