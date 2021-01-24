    SqlConnection conn = new SqlConnection(Properties.Settings.Default.constring.ToString());
    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CLIENT where cod_cli="some_specific_string", conn);
    DataSet ds = new DataSet();
    da.Fill(ds, "CLIENT");
    //Populate the combobox
    COMBOBOX1.ItemsSource = ds.Tables[0].DefaultView;
    COMBOBOX1.DisplayMemberPath = "FR";`enter code here`
    COMBOBOX1.SelectedValuePath = "FC";
