    List<int> userIds=new List<int>();  //Have to declare your list in which you can store all userid's
    using (SqlConnection conn = new SqlConnection(conString))
               {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT UserId,Status FROM NewUsers", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            While(reader.read())
                            {
                             userIds.Add(Convert.ToIn32(treader["UserId"].ToString())); 
                            }
                        }
                    }
                }
