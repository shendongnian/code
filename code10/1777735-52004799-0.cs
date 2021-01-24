    using (SqlConnection Con = new SqlConnection(Connectionstring.selectedBrugerString))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT USERNAME FROM PERSONAL", Con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                    while (reader.Read())
                    {
                        fromComboBox.Items.Add(reader[0]);
                        toComboBox.Items.Add(reader[0]);
                    }
                }
                var countUsers = fromComboBox.Items.Count;
                movePostMessage.Text = countUsers + " brugere er fundet";
            }
        }
