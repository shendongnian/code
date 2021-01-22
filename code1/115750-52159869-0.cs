     foreach (GridViewRow row in Gridname.Rows)
     {
          TextBox txttotal = (TextBox)row.FindControl("textboxid_inside_grid");
          string var = txttotal.Text;
          Response.Write("Textbox value = " + var);
     }
