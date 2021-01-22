    using System.Data.OleDb; 
    using System.IO; 
    
    static class Module1 
    { 
        public static void Main() 
        { 
            OleDbConnection oConn = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=C:\\"); 
            OleDbCommand oCmd = new OleDbCommand(); 
            
            { 
                oCmd.Connection = oConn; 
                oCmd.Connection.Open(); 
                // Create a sample FoxPro table 
                oCmd.CommandText = "CREATE TABLE Table1 (FldOne c(10))"; 
                oCmd.CommandType = CommandType.Text; 
                oCmd.ExecuteNonQuery(); 
            } 
            
            oConn.Close(); 
            oConn.Dispose(); 
            oCmd.Dispose(); 
        } 
    } 
