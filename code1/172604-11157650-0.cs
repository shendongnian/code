    public partial class ScannedItemsTableAdapter
    {
        public void InitEvents()
        {
            this._adapter.RowUpdated += _adapter_RowUpdated;
        }
        void _adapter_RowUpdated(object sender, SqlCeRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue && 
                e.StatementType == StatementType.Insert)
            {
                var pk = e.Row.Table.PrimaryKey;
                pk[0].ReadOnly = false;
                SqlCeCommand cmd = new SqlCeCommand("SELECT @@IDENTITY", 
                   e.Command.Connection, e.Command.Transaction);
                object id = (decimal)cmd.ExecuteScalar();
                e.Row[pk[0]] = Convert.ToInt32(id);
                e.Row.AcceptChanges();
            }
        }
    }
