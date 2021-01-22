    //pseudo-code
    
    class MyWebMethods {
    
      private static DataTable localDataTable;
      static MyWebMethods() {
        localDataTable = new DataTable();
        //Do whatever else is needed here to populate the table
      }
    
      [WebMethod]
      public string GetSomeData(int id) {
        //Query localDataTable using parameter info
        //return result
      }
    }
