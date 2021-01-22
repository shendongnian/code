            static void Main(string[] args)
            {
                SqlConnection myConnection = new SqlConnection("user id=userid;" +
                                           "Password=validpassword;" +
                                           "Trusted_Connection=yes;" +
                                           "Data Source=localhost;" +
                                           "connection timeout=300");
    
    
                try
                {
                    myConnection.Open();
    
                    SqlCommand myCommand = new SqlCommand("INSERT INTO table (Column1, Column2) " +
                                          "Values ('string', 1)", myConnection);
                    myCommand.ExecuteNonQuery();    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
