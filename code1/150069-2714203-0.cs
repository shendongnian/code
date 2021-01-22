    ///<summary>Gets the rows in a typed DataTable that have not been deleted.</summary>
    public static EnumerableRowCollection<TRow> CurrentRows<TRow>(this TypedTableBase<TRow> table) where TRow : DataRow { 
        return table.Where(r => r.RowState != DataRowState.Deleted); 
    }
    foreach (myDataTableRow row in _dt.CurrentRows())
    {
        ...
