    private DataSet ds = null; // initialize dataset with null value
    private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (ds == null) // initialize dataset on demand with all possible values from database
        {
            de = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select p_id_pk,p_name FROM products", con);
            da.Fill(ds, "products");
    
            comboBox3.ItemsSource = ds.Tables[0].DefaultView;
            comboBox3.DisplayMemberPath = ds.Tables[0].Columns["p_name"].ToString();
            comboBox3.SelectedValuePath = ds.Tables[0].Columns["p_id_pk"].ToString();
            return;
        }
    
        // filter view based on text input
        ds.Tables[0].DefaultView.RowFilter = "p_name like '"+ comboBox3.Text + "%'";
    }
