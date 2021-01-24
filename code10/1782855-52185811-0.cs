    public void InsertRecord(Account loggedInUser)
                {
                    Connection connection = new Connection();
                    try
                    {
                        string sql = "INSERT INTO tbl_Item VALUES (@itemId, @itemName, @logId)";
                        MySqlConnection conn = new MySqlConnection(connection.ConnectionString);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@itemId", ItemId)); // Why you called GenerateID() second time? It was generated in button1_Click
                        cmd.Parameters.AddWithValue("@itemName", ItemName);
                        cmd.Parameters.AddWithValue("@logId", loggedInUser.UserID);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
    
                        MessageBox.Show("Update Successfully", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("An error occurred: " + e, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
    
    //my code for btnAdd
    private void button1_Click(object sender, EventArgs e)
            {
                Item item = new Item();
    
                item.ItemID = item.GenerateID();
                item.ItemName = textBox2.Text;
                //item.Account.UserID = item.Account.GenerateID(); do you really need this?
    // someLoggedInUser is Account
                item.InsertRecord(someLoggedInUser);
            }
