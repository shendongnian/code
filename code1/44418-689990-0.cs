    public static int UpdateItem(int parameter1, int parameter2, string parameter3)
        {
            SqlParameter[] arParam = new SqlParameter[3];
            arParam[0] = new SqlParameter("@Parameter1", lotId);
            arParam[1] = new SqlParameter("@Parameter2", saleId);
            arParam[2] = new SqlParameter("@Parameter3", lotNumber);
  
            return int.Parse(SqlHelper.ExecuteScalar(connString, CommandType.StoredProcedure, "spName", arParam).ToString(), CultureInfo.InvariantCulture);
        }
