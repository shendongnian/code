    using (connection)
                {
                    //LIMIT 5 DESC from ID which shows last 5 work outs 
                    SqlCommand myCommand = new SqlCommand("SELECT * FROM Strength",
                                                        connection);
                    connection.Open();
    
                    SqlDataReader read = myCommand.ExecuteReader();
    
                    string result = "<table class=\"table table-striped top - buffer\" table style=\"width:300px\">" +
                "<tr><th>Weight(KG)</th><th>Reps</th></tr>";
               
    
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Id = read["Id"].ToString();
                            System.Diagnostics.Debug.WriteLine(Id);
    
                            Weight = read["Weight"].ToString();
                            System.Diagnostics.Debug.WriteLine(Weight);
    
                            Rep = read["Rep"].ToString();
                            System.Diagnostics.Debug.WriteLine(Rep);
    
                           result += "<tr><td>" + Weight + "</td>" +
                             "</tr><tr><td>" + Rep + "</td></tr>";
                        }
                    }
                    else
                    {
                        Console.WriteLine("nothing");
                    }
                    read.Close();
    
                    ViewBag.HtmlStr = result + "</table>";
                }
