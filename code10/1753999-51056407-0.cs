    private void buttonAddrecord_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = (@"Provider= Microsoft.ACE.OLEDB.12.0;Data Source =C:\Users\pc\Documents\Visual Studio 2015\Projects\GamefarmDB\GamefarmDB\Gamefarm.accdb;User ID = admin;");
        String WingbandNumber = wingbandnumberTextbox.Text;
        String DateOfHatch = dateofhatchTextbox.Text;
        String Markings = markingsTextbox.Text;
        String Bloodline = bloodlineTextbox.Text;
        String Broodhen = broodhenTextbox.Text;
        String Broodcock = broodcockTextbox.Text;
        OleDbCommand cmd = new OleDbCommand("INSERT into List (WingbandNumber, DateOfHatch, Markings, Bloodline, Broodhen, Broodcock) Values(@WingbandNumber, @DateOfHatch, @Markings, @Bloodline, @Broodhen, @Broodcock)");
        cmd.Connection = conn;
        conn.Open(); // To Open Connection
        if (conn.State == ConnectionState.Open)
        {
            cmd.Parameters.Add("@WingbandNumber", OleDbType.Numeric).Value = WingbandNumber;
            cmd.Parameters.Add("@DateOfHatch", OleDbType.LongVarChar).Value = DateOfHatch;
            cmd.Parameters.Add("@Markings", OleDbType.LongVarChar).Value = Markings;
            cmd.Parameters.Add("@Bloodline", OleDbType.LongVarChar).Value = Bloodline;
            cmd.Parameters.Add("@Broodhen", OleDbType.LongVarChar).Value = Broodhen;
            cmd.Parameters.Add("@Broodcock", OleDbType.LongVarChar).Value = Broodcock;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Added");
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Source);
                conn.Close();
            }
        }
        else
        {
            MessageBox.Show("Connection Failed");
        }
    }
