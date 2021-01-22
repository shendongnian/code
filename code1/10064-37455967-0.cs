    private DataTable CompareDT(DataTable TableA, DataTable TableB)
        {
            DataTable TableC = new DataTable();
            try
            {
    
                var idsNotInB = TableA.AsEnumerable().Select(r => r.Field<string>(Keyfield))
                .Except(TableB.AsEnumerable().Select(r => r.Field<string>(Keyfield)));
                TableC = (from row in TableA.AsEnumerable()
                          join id in idsNotInB
                          on row.Field<string>(ddlColumn.SelectedItem.ToString()) equals id
                          select row).CopyToDataTable();
            }
            catch (Exception ex)
            {
                lblresult.Text = ex.Message;
                ex = null;
             }
            return TableC;
    
        }
