        public DataTable selectdata(string Qry)
        {
            try
            {
            var datatable = new DataTable();
            conn.Open();
            MySqlDataAdapter obj = new MySqlDataAdapter(Qry, conn);
            obj.Fill(datatable);
            conn.Close();
            return datatable;
            }
            catch (MySqlException)
            {
                return new DataTable();
            }
        }
