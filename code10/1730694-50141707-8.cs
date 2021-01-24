    public IEnumerable<T> LoadList<T>(DataGridView dgv, int cell)
    {
        if ((dgv == null) || (dgv.RowCount == 0)) return null;
        IEnumerable<T> result = null;
        try
        {
            result = dgv.Rows.Cast<DataGridViewRow>()
                             .Select(r => { return r.Cells[cell].Value != null
                                       ? (T)Convert.ChangeType(r.Cells[cell].Value, typeof(T))
                                       : default;
                                })
                             .ToList();
        }
        catch (Exception ex) {
            //Manage the exception as required
            throw ex;
        }
        return result;
    }
