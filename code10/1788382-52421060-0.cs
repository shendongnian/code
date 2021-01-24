    public ResultSet getData()
    {
         ResultSet objResultSet = new ResultSet(); 
         objResultSet.RowsInserted = result;
         objResultSet.RequestStatus = "SuccessFul";
         return objResultSet;
    }
