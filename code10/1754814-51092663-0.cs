    private void btnT_Click(object sender, EventArgs e)
    {
     SqlConnection cn = new SqlConnection("data source = TURKY-PC ; initial 
     catalog = coffeeshopDB ; integrated security = true ; ");            
     SqlCommand cmd;                      
     SqlDataReader dr;        
     cmd = new SqlCommand("select SUM (cost) as TotalCost from billTB", cn);             
     cn.Open();       
     dr = cmd.ExecuteReader();    
     while (dr.Read())            
       {                
         btnT.Text = dr["TotalCost"].ToString();     
       }         
      dr.Close();      
      cn.Close();       
    }
