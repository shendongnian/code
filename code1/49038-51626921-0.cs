                string connetionString = "Data Source=.;Initial Catalog=your DB name;Integrated Security=True;MultipleActiveResultSets=True";
                using (SqlConnection conn = new SqlConnection(connetionString)){
                string getTeamDetailsQuery = "select * from Team";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(getTeamDetailsQuery, conn))
                        {
                            SqlDataReader rdr = cmd.ExecuteReader();
                        {
                            teamDetails.Add(new Team_Details
                            {
                                Team_Name = rdr.GetString(rdr.GetOrdinal("Team_Name")),
                                Team_Lead = rdr.GetString(rdr.GetOrdinal("Team_Lead")),
                            });
                        }
