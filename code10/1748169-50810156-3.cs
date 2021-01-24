     protected void Gridview_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                  string designation =  Gridview.SelectedRow.Cells[0].Text;
                }
                catch (Exception ex)
                {        
                }
            }
