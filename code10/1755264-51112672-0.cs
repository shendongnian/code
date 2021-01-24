    private void combonacionalidad_Loaded(object sender, RoutedEventArgs e)
    {
        ora.Open();
        OracleCommand comm = new OracleCommand("select idnacionalidad, nacionalidad from nacionalidad ", ora);
        comm.CommandType = System.Data.CommandType.Text;
    
        OracleDataAdapter oda = new OracleDataAdapter(comm);
    
        DataTable dt = new DataTable();
        oda.Fill(dt);
        combonacionalidad.ItemsSource = dt.AsDataView();
        combonacionalidad.DisplayMemberPath = "nacionalidad";
        combonacionalidad.SelectedValuePath = "idnacionalidad";
    }
