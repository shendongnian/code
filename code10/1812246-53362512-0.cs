    public void FunDataGrid_DataView(DataGrid dg, string qry)
    {
        con = new SqlConnection(con_string);
        cmd = new SqlCommand(qry, con);
        cmd.CommandTimeout = 12 * 3600;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        Application.Current.Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  new Action(() =>
                  {                       
                      try
                      {
                          dg.ItemsSource = dt.DefaultView;
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }                                                                      
                  }));                            
    }
