    private void InsertScores(int scoreId, int scoreValue, string Username)
        {
    
                //Connection
                Connection();
    
                    //Select All rows and populate object instance
                    SqlCommand cmd = new SqlCommand("SELECT * FROM gameScores Order By scoreValue ASC", Con);
                    //data reader
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
    					Score score = new Score(); //Create object to store the data
                        score.ScoreId = Convert.ToInt32(rdr[0].ToString());
                        score.ScoreTurns = Convert.ToInt32(rdr[1].ToString());
                        score.ScoreUsername = rdr[2].ToString();
                        Scores.Add(score); //Add the object to the array
                    }
                    rdr.Close();
    
                //int ScoreId = 9;
                if (scoreValue < Scores[9].ScoreTurns)
                {
                    SqlCommand sql = new SqlCommand("UPDATE gameScores SET scoreValue = @scoreValue, username = @Username WHERE scoreid = @ScoreId;", Con);
                    sql.Parameters.AddWithValue("@scoreValue", scoreValue);
                    sql.Parameters.AddWithValue("@Username", Username);
                    sql.Parameters.AddWithValue("@ScoreId", Scores[9].ScoreId);
                    //Insert
                    sql.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("You sadly have not made the High Scores Leaderboard");
                }
    
    
        } 
