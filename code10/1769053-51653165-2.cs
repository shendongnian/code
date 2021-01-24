    using System;
    using System.Data;
    using System.Data.Odbc;
       class CommandOdbcExample{
    
          static void Main() {
         OdbcConnection comm = new OdbcConnection(@"DSN=MyOdbcdDB");
    	 OdbcCommand nonqueryCommand = comm.CreateCommand();
    
             try {
                comm.Open();
    
                nonqueryCommand.CommandText = "CREATE TABLE MyTable (Wartosc  int, Czas  datetime)";
                Console.WriteLine(nonqueryCommand.CommandText);
                nonqueryCommand.ExecuteNonQuery();
    
           
    
                
             } 
             catch (OdbcException ex) 
             {
                Console.WriteLine(ex.ToString());
             }
             finally 
             {  
                comm.Close();
                Console.WriteLine("Connection Closed.");
             }
          }
       }
