        static string Get_ManagedConnString(string Src_Name, ConnectionManager CM)
        {
            if (CM.CreationName != "OLEDB")
                throw new Exception(string.Format("Cannot get Conn String from non-OLEDB Conn manager {0}", CM.Name));
            RuntimeWrapper.IDTSConnectionManagerDatabaseParameters100 cmParams_Src = CM.InnerObject as RuntimeWrapper.IDTSConnectionManagerDatabaseParameters100;
            OleDbConnection oledbConn_Src = cmParams_Src.GetConnectionForSchema() as OleDbConnection;
            OleDbConnectionStringBuilder oledbCSBuilder_Src = new OleDbConnectionStringBuilder(oledbConn_Src.ConnectionString);
            SqlConnectionStringBuilder sqlCSBuilder_Src = new SqlConnectionStringBuilder();
            sqlCSBuilder_Src.DataSource = oledbCSBuilder_Src["Data Source"].ToString();
            sqlCSBuilder_Src.InitialCatalog = oledbCSBuilder_Src["Initial Catalog"].ToString();
            if (oledbCSBuilder_Src["integrated security"].ToString() == "SSPI")
            {
                sqlCSBuilder_Src.IntegratedSecurity = true;
            }
            else
            {
                sqlCSBuilder_Src.UserID = oledbCSBuilder_Src["User ID"].ToString();
                sqlCSBuilder_Src.Password = oledbCSBuilder_Src["Password"].ToString();
            }
            return sqlCSBuilder_Src.ConnectionString;
        }
