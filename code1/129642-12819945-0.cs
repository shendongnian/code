    private static bool SetServerProperties()
        {
            #region standardize Connection String
            string tempCatalog = "master";
            string temp = @"Data Source=" + dataSource + ";Initial Catalog=" + tempCatalog + ";Integrated Security=True;MultipleActiveResultSets=True";
            #endregion
            SqlConnection sqlconnection = new SqlConnection(temp);
            SqlCommand cmd = new SqlCommand("select @@ServerName", sqlconnection);
            sqlconnection.Open();
            string serverName = "";
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    serverName = dr[0].ToString();
            }
            catch
            {
                MessageBox.Show("Failed to Set SQL Server Properties for remote connections.");
            }
            Server srv = new Server(serverName);
            srv.ConnectionContext.Connect();
            srv.Settings.LoginMode = ServerLoginMode.Mixed;
            ManagedComputer mc = new ManagedComputer();
            try
            {
                Service Mysvc = mc.Services["MSSQL$" + serverName.Split('\\')[1]];
                if (Mysvc.ServiceState == ServiceState.Running)
                {
                    Mysvc.Stop();
                    Mysvc.Alter();
                    while (!(string.Format("{0}", Mysvc.ServiceState) == "Stopped"))
                    {
                        Mysvc.Refresh();
                    }
                }
                ServerProtocol srvprcl = mc.ServerInstances[0].ServerProtocols[2];
                srvprcl.IsEnabled = true;
                srvprcl.Alter();
                Mysvc.Start();
                Mysvc.Alter();
                while (!(string.Format("{0}", Mysvc.ServiceState) == "Running"))
                {
                    Mysvc.Refresh();
                }
                return true;
            }
            catch
            {
                MessageBox.Show("TCP/IP connectin could not be enabled.");
                return false;
            }
        }
