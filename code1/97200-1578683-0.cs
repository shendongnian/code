    private void BindtoGridViewFromTextBoxes(DataTable dt)
    {
        if (!String.IsNullOrEmpty(txtname.Text))
        {
            DataRow dr = dt.NewRow();
            dr["firstName"] = txtName.Text;
            dt.Rows.Add(dr);
            Session["Data"] = dt;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind(); 
    } 
