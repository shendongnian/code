       private void Load_BTN_Click_1(object sender, EventArgs e)
    {
        try
        {
           this.chart1.Series.Clear();
           this.chart1.Series.Add("Fuel_Amount");
            string selectQuery = "SELECT  DATEADD(week, DATEDIFF(week, 0, Date), 0) AS month, SUM(Fuel_Amount) AS Expr1 FROM Fuel_Attendend GROUP BY DATEADD(week, DATEDIFF(week, 0, Date), 0)";
            cmd = new SqlCommand(selectQuery, connection);
            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.chart1.Series["Fuel_Amount"].Points.AddY(dr.GetInt32(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
