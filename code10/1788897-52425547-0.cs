    private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                string MySQLConn = "datasource=localhost;port=3306;username=root;password=root;";
                MySqlConnection myConn = new MySqlConnection(MySQLConn);
                myConn.Open();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string price = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string Query = "INSERT INTO db1.table1 (price) VALUES ('"+ price + "');";
                    MySqlCommand MySQLcmd = new MySqlCommand(Query, myConn);
                    MySQLcmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
