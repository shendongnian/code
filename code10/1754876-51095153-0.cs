    void addlabel(int i, int start, int end)
    {
        string conStr = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        using (SqlConnection conObject = new SqlConnection(conStr))
        {
            conObject.Open();
            string querySql = "SELECT subjects FROM marks  WHERE idno like @idInputs";
            using (SqlCommand cmdSql = new SqlCommand(querySql, conObject))
            {
                cmdSql.Parameters.Add(" @idInputs", SqlDbType.VarChar).Value = "%" + textBox1.Text + "%";
                using (SqlDataReader reader = cmdSql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         var input = reader["subjects"].ToString();
                         var split = input.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                         for (int j = 0; j < split.Length; j++)
                         {
                            Label newLabel = new Label();
                            newLabel.Name = "label" + i.ToString();
                            newLabel.Text = split[j] + i.ToString();
                            this.Controls.Add(newLabel);
                         }
                    }
                }
            }
        }
    }
