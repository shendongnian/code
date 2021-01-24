    SqlCommand displayCharactersCMD = new SqlCommand(String.Format("SELECT FullName FROM [Characters] WHERE Username='{0}'", username), con);
    displayCharactersCMD.Parameters.AddWithValue("@checkPlayerName", username);
    var characterReader = new List<string>;
    using (SqlDataReader reader = displayCharactersCMD.ExecuteReader())
            {                
                while (reader.Read())
                {
                    characterReader.Add(reader[0].ToString());                
                }
            }
