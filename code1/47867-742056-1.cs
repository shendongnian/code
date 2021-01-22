    private void DataGridView1_UserDeletingRow(object sender,
                                               DataGridCommandEventArgs e)
    {
        TableCell itemCell = e.Item.Cells[0]; // assumes id is in column 0
        int id = int.Parse(item.Text); // assumes it's non-null
        using (var dc = new SiteDataDataContext())
        {
             var site = dc.Sites.Where(s => s.ID == id).SingleOrDefault();
             
             if (site != null)
             {
                 try
                 {
                    dc.Sites.DeleteOnSubmit( site );
                    dc.SubmitChanges();
                    dataGridView1.Bind();
                 }
                 catch (SqlException)
                 {
                    e.Cancel = true;
                 }
             }
         }
    }
