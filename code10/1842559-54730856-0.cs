        private List<string> CategoriesPicker = new List<string>();
        //add all the items to the list
        private void SavedItemsButton_Clicked(object sender, System.EventArgs e)
        {
            string sqlstring = "server=; port= ; user id =;Password= ;Database=test;";
            using (MySqlConnection conn = new MySqlConnection(sqlstring))
            {
                string Query = "INSERT INTO test.maintable (Categories)values(@Category);";
                using (MySqlCommand cmd = new MySqlCommand(Query, conn))
                {
                    cmd.Parameters.Add("@Category", MySqlDbType.VarChar);
                    try
                    {
                        conn.Open();
                    }
                    catch (MySqlException ex)
                    {
                        throw ex;
                    }
                    foreach (String item in CategoriesPicker)
                    {
                        cmd.Parameters["@Category"].Value = item;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
