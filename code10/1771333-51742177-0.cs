    string str = "server=test; database=test; uid=test; pwd=test;";
    
    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
    {
         using (MySqlConnection constr = new MySqlConnection(str))
         {
             constr.Open();
             // if '@' prefix for parameters not working, change to '?'
             String cmdText = "INSERT INTO KPI_Kosten (Betrag, Tower, Jahr, Periode, Land) VALUES (@Betrag, @Tower, @Jahr, @Periode, @Land)";
             using (MySqlCommand cmd = new MySqlCommand(cmdText, constr))
             {
                // if you're experiencing too many parameters error, uncomment this line below
                // cmd.Parameters.Clear();
    
                MySqlParameter betrag = new MySqlParameter("@Betrag", MySqlDbType.Decimal);
                betrag.Precision = 10;
                betrag.Scale = 2;
                betrag.Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[0].Value);
                cmd.Parameters.Add(betrag);
                cmd.Parameters.Add("@Tower", MySqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
    
                // other parameters
    
                cmd.ExecuteNonQuery();
             }
         }
    }
