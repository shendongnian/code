    public void LoadData(int dateID)
    {
       using(SqlConnection conn = new SqlConnection("Data Source=mycbj01psql03\\sandbox01;Initial Catalog=DBRMS;Integrated Security=True"))
       {
           using(SqlCommand command = new SqlCommand("p_Date_sel", conn))
           {  
               command.CommandType = CommandType.StoredProcedure;
 
               // define the parameter and give it a value!
               command.Parameters.Add("@DateID", SqlDbType.Int);
               command.Parameters["@DateID"].Value = dateID;
            
               conn.Open();
             
               using(SqlDataReader reader = command.ExecuteReader())
               {
                  while (reader.Read()) 
                  {
                     _dateTypeID = Convert.ToInt16(reader["DateTypeID"]);
                     _date = Convert.ToDateTime(reader["Date"]);
                     _name = reader["Name"].ToString();
                     _notes = reader["Notes"].ToString();
                  }
                  reader.Close();
               }
   
               conn.Close();
            }
       }
