     protected void GridView1_DataBound(object sender, EventArgs e)
     {
         int rowCount = GridView1.Rows.Count;
         if (rowCount == 0)
         {
             GridView1.Visible = false;                
         }
         else
         {
            GridView1.Visible = true;
         }
     }
