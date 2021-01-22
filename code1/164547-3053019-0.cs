     public bool BeginTransaction(string strServerName)
        {
            try
            {
                bool bRet = OpenConnection(strServerName);
                if (bRet)
                {
                    m_objTransaction = m_conn.BeginTransaction();
                    m_dtAdapter.SelectCommand.Connection = m_conn;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    public bool OpenConnection(string strServerName)
        {
            try
            {
                m_connStr = string.Empty;
                m_connStr = string.Format("Data Source=;Initial Catalog=;User Id=sa;Password=;"); //write your credentials here with DB name and server
                m_conn = new SqlConnection(m_connStr);
                m_conn.Open();
                m_dtAdapter = new SqlDataAdapter();
                if (m_conn != null)
                {
                    m_dtAdapter.SelectCommand = new SqlCommand();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
