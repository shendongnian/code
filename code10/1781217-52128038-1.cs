     foreach (GridDataItem item in RadGrid1.Items)
        {
            string id = item["ID"].Text;
            string firstName = (item["TempColumn1"].FindControl("PRODQUANTLabel") as Lable).Text;
        }
    
    protected void GridView1_RowUpdating(object sender,idViewUpdateEventArgs e)
      {
                  GridView gv = (GridView)sender;
                  GridViewRow gvRow = gv.Rows[e.RowIndex];
                  Lable tb = (Lable) gridview1.FindControl("PRODQUANTLabel");
                  if (tb == null)
                     throw new ApplicationException("Could not find Lable");
                
                  string strValue= tb.Text;
                 
       }
