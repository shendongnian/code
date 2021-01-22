    protected void GridView1_PreRender(object sender, EventArgs e)
     {
      if (this.GridView1.EditIndex != -1)
       {
         Button b = GridView1.Rows[GridView1.EditIndex].FindControl("Button1") as Button;
         if (b != null)
          {
          //do something
          }
       }
     }
