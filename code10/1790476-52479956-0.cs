      void grd_CurrentCellDirtyStateChanged(object sender, EventArgs e)
                {
                    if (grd.IsCurrentCellDirty)
                        grd.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
        
    
        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
        
        
                if (e.ColumnIndex == 1) //compare to checkBox column index
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)grd[e.ColumnIndex, e.RowIndex];
                    if (!DBNull.Value.Equals(cbx.Value) && (bool)cbx.Value == true)
                    {
                        //checkBox is checked - do the code in here!
                    }
                    else
                    {
                        //if checkBox is NOT checked (unchecked)
                    }
                }
            }
