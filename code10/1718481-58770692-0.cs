    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(((Label)gvListadoActividades.Rows[e.RowIndex].FindControl("MyId")).Text);
            this.DeletedMyid(id);
            this.GridView1.EditIndex = -1;
            this.LoadMyData();
        } 
