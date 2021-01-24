    public void llenagrid()
      {
              DataTable table = new DataTable();
              using (SqlConnection conn = new SqlConnection(connStrr))
              {
                  string sql = "SELECT id_unidad, nombre, fracciones, clave_sat from unidades";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(table);
                        }
                   }
               }
          //IncrementoID(); // Remove the function call from here
          GridView1.DataSource = table;
          GridView1.DataBind(); 
          IncrementoID();  // Call the function after GridView got binded.      
       }
 
