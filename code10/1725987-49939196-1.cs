    SqlCommand displayCharactersCMD = new SqlCommand("SELECT FullName FROM [Characters] WHERE Username=@checkPlayerName");
    displayCharactersCMD.Parameters.AddWithValue("@checkPlayerName", username);
    var characterReader = new List<string>();
    using (SqlDataReader reader = displayCharactersCMD.ExecuteReader())
            {                
                while (reader.Read())
                {
                    characterReader.Add(reader[0].ToString());                
                }
            }
