    public boolean CheckExists(string TableName, string ColumnName, int ID) {
      //Connect to database
      // Create Command with query  "SELECT COUNT(1) FROM " + TableName.Replace(";","") + " WHERE " + ColumnName.Replace(";","") + " = " + ID 
      Return int.Parse(myQuery.ExecuteScalar) > 0
     //disconnect
    }
    
     
     public boolean UpdateCredit(int CustID, int newCredit) {
      //Connect to database
      // Create Command with query  "UPDATE CustTable SET CustCredit = " + newCredit.ToString() + " WHERE = CustId = " + CustID 
      myQuery.ExecuteNonQuery
    //disconnect
    }
    public boolean CreateCredit(int CustID, int newCredit) {
      //Connect to database
      // Create Command with query  "INSERT INTO CustTable (CustID, CustCredit) VALUES (" + CustId.ToString + ", " + newCredit.ToString + ")"
      myQuery.ExecuteNonQuery
      //disconnect
    }
