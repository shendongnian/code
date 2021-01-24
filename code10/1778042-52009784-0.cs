    private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchtext = comboBox3.Text;
        comboBox3.ItemsSource = null;
        SqlDataAdapter da = new SqlDataAdapter("Select p_id_pk,p_name FROM products where p_name like '" + comboBox3.Text + "'+'%'", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "products");
        comboBox3.ItemsSource = ds.Tables[0].DefaultView;
        comboBox3.DisplayMemberPath = ds.Tables[0].Columns["p_name"].ToString();
        comboBox3.SelectedValuePath = ds.Tables[0].Columns["p_id_pk"].ToString();
        comboBox3.Text = searchtext;  
    }
