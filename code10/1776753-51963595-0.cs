    if (dt.Rows.Count > 0)
    {
        GridView1.DataBind();
    }
    else
    {
        Lab4.Text = "No Records Found ";
    }
    myConn.Close();
    
    private void Retrieve()
            {
                  if(loadPositions() != null){
    				dgvEmployeePositions.DataSource = loadPositions();
    			  }
    			  else{
    				  Lab4.Text = "No Records Found ";
    			  }
          
                
            }
     
     private DataTable loadPositions()
            {
                DataTable dt = new DataTable();;
                myConn.Open(); 
                String q = "your query here";
                MySqlCommand cmd = new MySqlCommand(q, connectionString);
                MySqlDataReader r = cmd.ExecuteReader();
    
    			if(r.hasRows){
    				dt.Load(r);	
    				return dt;			
    			}
    			else{
    				return null;
    			}				
                
                
            }
