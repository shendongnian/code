    using System.Data.OleDb;
    using System.Data;
    OleDbConnection oConn = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=C:\\PathToYourDataDirectory"); 
    OleDbCommand oCmd = new OleDbCommand(); 
    oCmd.Connection = oConn; 
    oCmd.Connection.Open(); 
    oCmd.CommandText = "select * from SomeTable where LEFT(StudentName,1) = 'A'"; 
    
    // Create an OleDBAdapter to pull data down
    // based on the pre-built SQL command and parameters
    OleDbDataAdapter oDA = new OleDbDataAdapter(oCmd);
    DataTable YourResults
    oDA.Fill(YourResults);
    oConn.Close(); 
    // then you can scan through the records to get whatever
    String EachField = "";
    foreach( DataRow oRec in YourResults.Rows )
    {
      EachField = oRec["StudentName"];
      // but now, you have ALL fields in the table record available for you
    }
