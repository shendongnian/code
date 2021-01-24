    static void Main()
            {
                string connectionString = "Server=127.0.0.1;Uid=root;Pwd=<password here>;Database=Test;";
                string selectString = "Select id, Nutzfläche FROM TestTable";
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectString, connectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                DataTable dt = dataset.Tables[0];
                foreach (DataRow dataRow in dt.Rows)
                {
                    string testFloatColumn = dataRow[1].ToString();
                    string testFloatColumn2 = dataRow["Nutzfläche"].ToString();
                }
            }
