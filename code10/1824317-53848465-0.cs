        public DataTable selectdata(string Qry)
        {
            try
            {
            var datatable = new DataTable();
            conn.Open();
            SqlDataAdapter obj = new SqlDataAdapter(Qry, conn);
            obj.Fill(datatable);
            conn.Close();
            return datatable;
            }
            catch (SqlException)
            {
                return new DataTable();
            }
        }
