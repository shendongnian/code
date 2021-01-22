    using (DataTable dt = new DataTable())
    {
        using (OdbcConnection cnDsn = new OdbcConnection(cmLocalTrackingDBDSNAME))
        {
            cnDsn.Open();
            using (OdbcCommand cmdDSN = new OdbcCommand())
            {
                      var _with1 = cmdDSN;
                      _with1.Connection = cnDsn;
                      _with1.CommandType = System.Data.CommandType.StoredProcedure;
                      _with1.CommandText = "{ CALL ps_Clients_Get }";
                      using (OdbcDataAdapter adapter = new OdbcDataAdapter())
                      {
                                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                                adapter.SelectCommand = cmdDSN;
                                adapter.Fill(dt);
                                bindingSourceDataLocation.DataSource = dt;
                                dataGridViewDataLocation.AutoGenerateColumns = false;
                                                               
                                dataGridViewDataLocation.DataSource = bindingSourceDataLocation;
                      }
             }
             cnDsn.Close();
        }
    }
