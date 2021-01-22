    private void DataGridView1_UserDeletingRow(object sender,
                                               DataGridViewRowCancelEventArgs e)
    {
        DataGridViewRow row = sender as DataGridViewRow;
        int id = ...get id from row column...
        using (var dc = new SiteDataDataContext())
        {
             var site = dc.Sites.Where( s => s.ID == id ).SingleOrDefault();
             
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
