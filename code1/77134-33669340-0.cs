    public class ADOUtility
    {
        private string _connectionstring;
        private SqlConnection DbConn;
        private bool DBStatus;
        public int CmdTimeOut;
        public string ConnectionString
        {
            set { _connectionstring = value; }
        }
        
        public ADOUtility(string connstr)
        {
            _connectionstring = connstr;
            CmdTimeOut = -1;
            DBStatus = false;
        }
        public ADOUtility()
        {
            DBStatus = false;
            CmdTimeOut = -1;
        }
        /// <summary>Create and opens a new connection </summary>
        public void Open()
        {
            try
            {
                DbConn = new SqlConnection();
                DbConn.ConnectionString = _connectionstring;
                DbConn.Open();
                DBStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void IsConnOpen()
        {
            try
            {
                if (DbConn.State == ConnectionState.Closed)
                {
                    Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Boolean IsOpen()
        {
            return DBStatus;
        }
        
        public void Close()
        {
            if (IsOpen())
            {
                DbConn.Close();
                DbConn.Dispose();
                DBStatus = false;
            }
        }
       
        public Int16 Insert(string SqlQuery, params SqlParameter[] SqlParam)
        {
            IsConnOpen();
            Int16 newProdID = 0;
            SqlCommand cmd = default(SqlCommand);
            SqlQuery += ";SELECT CAST(SCOPE_IDENTITY() AS int);";
            cmd = new SqlCommand(SqlQuery, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            foreach (SqlParameter param in SqlParam)
            {
                cmd.Parameters.Add(param);
            }
            
            newProdID = Convert.ToInt16(cmd.ExecuteScalar());
            return newProdID;
        }
        
        public Int64 Execute(string SqlQuery)
        {
            IsConnOpen();
            Int64 newProdID = 0;
            SqlCommand cmd = new SqlCommand(SqlQuery, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            newProdID = Convert.ToInt64(cmd.ExecuteNonQuery());
            return newProdID;
        }
       
        public Int64 Execute(string SqlQuery, params SqlParameter[] SqlParam)
        {
            IsConnOpen();
            SqlCommand cmd = new SqlCommand(SqlQuery, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            foreach (SqlParameter param in SqlParam)
            {
                cmd.Parameters.Add(param);
            }
            return Convert.ToInt64(cmd.ExecuteNonQuery());
        }
       
        public object SP_Execute(string SpName, params SqlParameter[] SqlParam)
        {
            IsConnOpen();
            SqlCommand cmd = new SqlCommand(SpName, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter param in SqlParam)
            {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteScalar();
        }
        
        public object SelectColumn(string SqlQuery, params SqlParameter[] SqlParam)
        {
            IsConnOpen();
            SqlCommand cmd = new SqlCommand(SqlQuery, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            cmd.CommandType = CommandType.Text;
            foreach (SqlParameter param in SqlParam)
            {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteScalar();
        }
       
        public object SelectColumn(string tablename, string columnname, string condition)
        {
            IsConnOpen();
            if (!string.IsNullOrEmpty(condition))
            {
                condition = "where " + condition;
            }
            string query = null;
            query = "select " + columnname + " from " + tablename + " " + condition;
            SqlCommand cmd = new SqlCommand(query, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dbtable = new DataSet();
            adapter.Fill(dbtable, tablename);
            if (dbtable.Tables[tablename].Rows.Count > 0)
            {
                return dbtable.Tables[tablename].Rows[0][0];
            }
            else
            {
                return "no_record_found";
            }
        }
       
        public DataTable Select_Table(string SqlQuery)
        {
            IsConnOpen();
            SqlCommand cmd = new SqlCommand(SqlQuery, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dbtable = new DataSet();
            adapter.Fill(dbtable, "recordset");
            return dbtable.Tables["recordset"];
        }
       
        public DataTable Select_Table(string SqlQuery, params SqlParameter[] SqlParam)
        {
            IsConnOpen();
            SqlCommand cmd = new SqlCommand(SqlQuery, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foreach (SqlParameter param in SqlParam)
            {
                cmd.Parameters.Add(param);
            }
            DataSet dbtable = new DataSet();
            adapter.Fill(dbtable, "recordset");
            return dbtable.Tables["recordset"];
        }
        public int Select_Row(string SqlQuery, ref DataRow RowData, params SqlParameter[] SqlParam)
        {
            IsConnOpen();
            SqlCommand cmd = new SqlCommand(SqlQuery, DbConn);
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foreach (SqlParameter param in SqlParam)
            {
                cmd.Parameters.Add(param);
            }
            DataSet dbtable = new DataSet();
            adapter.Fill(dbtable, "recordset");
            if (dbtable.Tables["recordset"].Rows.Count > 0)
            {
                RowData = dbtable.Tables["recordset"].Rows[0];
                return dbtable.Tables["recordset"].Rows.Count;
            }
            else
            {
                RowData = null;
                return 0;
            }
        }
       
        public DataTable SP_Execute_Table(string SpName, params SqlParameter[] SqlParam)
        {
            IsConnOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SpName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = DbConn;
            if (CmdTimeOut >= 0)
            {
                cmd.CommandTimeout = CmdTimeOut;
            }
            foreach (SqlParameter param in SqlParam)
            {
                cmd.Parameters.Add(param);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dbtable = new DataSet();
            adapter.Fill(dbtable, "recordset");
            return dbtable.Tables["recordset"];
        }
    }
