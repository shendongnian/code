        public virtual bool Exists()
        {
            bool exists = false;
            string masterConnectionString = this.CreateConnectionString(this.Server, this.FailoverServer, "master");
        
            this.DBConnection.ConnectionString = masterConnectionString;
            this.DBConnection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.DBConnection;
                cmd.CommandText = "SELECT COUNT(name) FROM sysdatabases WHERE name = @DBName";
                cmd.Parameters.AddWithValue("@DBName", this.DBName);
                exists = (Convert.ToInt32(cmd.ExecuteScalar()) == 1);
            }
            finally
            {
                this.DBConnection.Close();
            }
            return exists;
        }
