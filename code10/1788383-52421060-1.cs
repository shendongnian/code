    public string getData()
    {
         ResultSet objResultSet = new ResultSet(); 
         objResultSet.RowsInserted = result;
         objResultSet.RequestStatus = "SuccessFul";
         return JsonConvert.SerializeObject(objResultSet);
    }
