        public static bool IsSQLConnectionAvailable()
        {
            SqlConnection _objConn = new SqlConnection();
            try
            {
                _objConn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultSQLConnectionString"].ConnectionString;
                _objConn.Open();
            }
            catch
            {
                return false;
            }
            finally
            {
                if (_objConn.State == ConnectionState.Open)
                    _objConn.Close();
            }
            return true;
        }
