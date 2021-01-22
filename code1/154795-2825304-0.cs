    DataSet myData = null;
    
    public DataSet GetMyData()
    {
       if (myData == null)
       {
          myData = GetDataFromDatabase();
       }
       return myData;
    }
