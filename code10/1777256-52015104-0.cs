    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
    DateTime nextDate;
    if (dsleaveplanner != null)
    {
            foreach (DataRow dr in dsleaveplanner.Tables[0].Rows)
            {
                nextDate = (DateTime)dr["date"];
                var hcount = (dr["headCount"].ToString());
                Int32 hcount1 = Convert.ToInt32(hcount);
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mydb;Uid=myid;Pwd=abc123;");
                string cntdate = "SELECT COUNT(date) FROM approved WHERE date = @date";
                string cntdate2 = "SELECT COUNT(date) FROM pending WHERE date = @date";
                MySqlCommand cmd2 = new MySqlCommand(cntdate, conn);
                MySqlCommand cmd3 = new MySqlCommand(cntdate2, conn);
                cmd2.Parameters.AddWithValue("@date", nextDate);
                cmd3.Parameters.AddWithValue("@date", nextDate);
                conn.Open();
                string count = cmd2.ExecuteScalar().ToString();
                string count2 = cmd3.ExecuteScalar().ToString();
                var slot2 = Convert.ToInt32(count);
                Int32 slot3 = hcount1 - slot2;
                string slot1 = Convert.ToString(slot3);
                string slot4 = slot3.ToString();
                conn.Close();
                samples.Add(new Sample { Date = nextDate, SlotAvailable = slot1, Pending = count2 });
                
            }
            if (samples.Any(x => x.Date == e.Day.Date))
                {
                    Environment.NewLine.ToString();
                    e.Cell.Font.Size = 11;
                    e.Cell.Controls.Add(new LiteralControl("<p></p>Slot available:"));
                    e.Cell.Controls.Add(new LiteralControl(samples.Where(x => x.Date == e.Day.Date).FirstOrDefault().SlotAvailable.ToString()));
                    e.Cell.Controls.Add(new LiteralControl("<p></p>Pending:"));
                    e.Cell.Controls.Add(new LiteralControl(samples.Where(x => x.Date == e.Day.Date).FirstOrDefault().Pending.ToString()));
                }
                else
                {
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                    e.Cell.Font.Size = 9;
                    e.Cell.Controls.Add(new LiteralControl("<p></p>Slot available:"));
                    e.Cell.Controls.Add(new LiteralControl(slot1));
                    e.Cell.Controls.Add(new LiteralControl("<p></p>Pending:0"));
                }
    }
