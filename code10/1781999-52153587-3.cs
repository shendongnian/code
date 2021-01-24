     public DataTable GetData()
       {
          //Move where you declare output ot here
          var output = new DataTable();
            
          using (var conn = new SqlConnection())
          {
                
        
             try
                {
                    conn.ConnectionString = //Your DataBase Connection;
           
                    String sql = "Select top 100 * from SEQUENCE";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.commandType = commandType.Text;
        
        
                    Var adapter = new SqlDataAdapter(cmd);
                    
            
                    adapter.Fill(output);
            
                         
            
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                               "ServerControlScript", ex.Message, true);
            
                    return (null);
            
                }
                 //And move the return to here 
                 return output;
           }
      }          
                
                
       //Should just need this to display the data
       GridViewOutput.DataSource = GetData();
       GridViewOutput.DataBind();
