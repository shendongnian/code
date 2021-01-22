        namespace databaseOp 
    { 
    public class dbOpnClse 
    { 
    SqlConnection con; 
    
    public SqlConnection openConnection() 
    { 
        //Try this...
        con = new SqlConnection("server=CHEMPAKASSERIL;database=Test;uid=sa;pwd=jeevan");
        
        //Not this...
        //con.ConnectionString ="server=CHEMPAKASSERIL;database=Test;uid=sa;pwd=jeevan"; 
        con.Open(); 
        return con; 
    } 
    
    public void closeConnection() 
    { 
        con.Close(); 
    }
        
        }
        
    }
