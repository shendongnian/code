       protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                var lbKategori = e.Row.FindControl("lbKategori") as Label;
                var lbAçıklama = e.Row.FindControl("lbAçıklama") as Label;
            }
        }
   
