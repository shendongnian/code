    public void Getproduct()
        {
            string sql;
            SqlConnection con = new SqlConnection("server =.; initial catalog=product; integrated security=true");
            SqlDataAdapter dapt;
            SqlDataReader dr1;
            sql = "SELECT id,product_name,product_desc,price FROM product Order By id Desc";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();
    
            int id;
            string pid;
    
            if (dr.Read() == true)
            {
                
                int val = 0;
    
                Int32.TryParse(dr[0].ToString(),out val);
    
                id = ( val + 1);
                pid = id.ToString("00000");
            }
            else if( Convert.IsDBNull(dr) )
                {
                    pid = ("00001");
    
                }
    
            }
