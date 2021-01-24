    public void Add(object sender, RoutedEventArgs e)
    {
        MessageBoxResult messageBoxResault = System.Windows.MessageBox.Show("Ali se prepričani?", "Potrditev vnosa", System.Windows.MessageBoxButton.YesNo);
        if (messageBoxResault == MessageBoxResult.Yes)
        {
            SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO cbu_naslovi VALUES ('" + ulica.Text + "','" + hisna_st.Text + "','" + id_hise.Text + "','" + postna_st.Text + "','" + obmocje.Text + "','" + katastrska_obcina.Text + "','" + st_objekta.Text + "','" + st_delov.Text + "','" + st_parcele_1.Text + "','" + st_parcele_2.Text + "','" + st_parcele_3.Text + "','" + st_parcele_4.Text + "','" + st_parcele_5.Text + "','" + st_parcele_6.Text + "','" + st_parcele_7.Text + "')",
                    Connection = con
                };
            cmd.ExecuteNonQuery();
            SaveID();
            sql_address.SelectedIndex = 0;
            SearchIndex();
            address.Content = ulica.Text.ToString() + " " + hisna_st.Text.ToString() + id_hise.Text.ToString();
            search.Text = string.Empty;
        }
    }
    public void SaveID()
    {
        DatagridIndex();
        sql_address.SelectedIndex = sql_address.Items.Count - 1;
        Public_Strings.saveID3 = Public_Strings.saveID1;
        Datagrid();
    }
    public void SearchIndex()
    {
        if (Public_Strings.saveID3 == Public_Strings.saveID1) { }
        else
        {
            sql_address.SelectedIndex++;
            SearchIndex();
        }
    }
    public void DatagridIndex()
    {
        SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM [cbu_naslovi] ORDER BY [ID] ASC",
                Connection = con
            };
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        dataGrid1 = new DataTable("cbu_naslovi");
        da.Fill(dataGrid1);
        sql_address.ItemsSource = dataGrid1.DefaultView;
    }
    public void Datagrid()
    {
        SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM [cbu_naslovi] ORDER BY [ULICA] ASC, LEN ([HS]) ASC, [HS] ASC, [HID] ASC",
                Connection = con
            };
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        dataGrid1 = new DataTable("cbu_naslovi");
        da.Fill(dataGrid1);
        sql_address.ItemsSource = dataGrid1.DefaultView;
    }
