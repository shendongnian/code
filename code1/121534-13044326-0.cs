    private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagrid1.SelectedRows)
            {
                //get key
                int rowId = Convert.ToInt32(row.Cells[0].Value);
                
                //avoid updating the last empty row in datagrid
                if (rowId > 0)
                {
                    //delete 
                    aController.Delete(rowId);
                    //refresh datagrid
                    datagrid1.Rows.RemoveAt(row.Index); 
                }  
            }
        }
     public void Delete(int rowId)
            {
                var toBeDeleted = db.table1.First(c => c.Id == rowId);
                db.table1.DeleteObject(toBeDeleted);
                db.SaveChanges();
            }
