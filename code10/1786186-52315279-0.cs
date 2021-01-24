    List<int> userIds=new List<int>();  //Have to declare your list
    using (SqlConnection conn = new SqlConnection(conString))
               {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT UserId,Status FROM NewUsers", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // looking for username and status in database check if is dealer or admin or unknown
                            While(reader.read())
                            {
                       userIds.Add(Convert.ToIn32(treader["UserId"].ToString()); 
                            }
                        }
                    }
                }
