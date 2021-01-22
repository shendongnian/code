    class clsDB
    {
        public SqlDataAdapter mDataAdapter = new SqlDataAdapter();
        public DataSet mDataSet = new DataSet();
        public SqlConnection mConn;
        public clsDB()
        {
            mConn = new SqlConnection("Data Source=(the data source);Initial Catalog=sample;User ID=(the id);Password=(the password)");
        }
        
        public void SQLDB(string strSQL)
        {
            try
            {
                mDataAdapter = new SqlDataAdapter(new SqlCommand(strSQL, mConn));
                mDataSet = new DataSet();
                mDataAdapter.Fill(mDataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mConn.Close();
            }
        }
        public void ClearRes()
        {
            mDataAdapter.Dispose();
            mDataAdapter = null;
            mDataSet.Dispose();
            if (mConn.State != ConnectionState.Closed)
            {
                mConn.Close();
            }
        }
    }
