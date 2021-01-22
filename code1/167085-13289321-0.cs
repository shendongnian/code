            FillCountry();
            
        }
        private void FillCountry()
        {
            string str = "SELECT CountryID, CountryName FROM Country";
            SqlCommand cmd = new SqlCommand(str,con);
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
           // cmd.CommandText = "SELECT CountryID, CountryName FROM Country";
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            comboBox1.ValueMember = "CountryID";
            comboBox1.DisplayMember = "CountryName";
            comboBox1.DataSource = objDs.Tables[0];
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != "")
            {
                int CountryID = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                FillStates(CountryID);
                comboBox3.SelectedIndex = 0;
            }
        }
        private void FillStates(int countryID)
        {
            string str = "SELECT StateID, StateName FROM State WHERE CountryID =@CountryID";
            SqlCommand cmd = new SqlCommand(str, con);
           // SqlConnection con = new SqlConnection(Con);
           //  cmd.Connection = con;          
           // string str="SELECT StateID, StateName FROM State WHERE CountryID =@CountryID";
           // cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
           // cmd.CommandText = "SELECT StateID, StateName FROM State WHERE CountryID =@CountryID";
            cmd.Parameters.AddWithValue("@CountryID", countryID);
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            if (objDs.Tables[0].Rows.Count > 0)
            {
                comboBox2.ValueMember = "StateID";
                comboBox2.DisplayMember = "StateName";
                comboBox2.DataSource = objDs.Tables[0];
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StateID = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            FillCities(StateID);
        }
        
        private void FillCities(int stateID)
        {
            //SqlConnection con = new SqlConnection(str,con);
            string str = "SELECT CityID, CityName FROM City WHERE StateID =@StateID";
            SqlCommand cmd = new SqlCommand(str,con);
           // cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
           // cmd.CommandText = "SELECT CityID, CityName FROM City WHERE StateID =@StateID";
            cmd.Parameters.AddWithValue("@StateID", stateID);
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            if (objDs.Tables[0].Rows.Count > 0)
            {
                comboBox3.DataSource = objDs.Tables[0];
                comboBox3.DisplayMember = "CityName"; 
                comboBox3.ValueMember = "CItyID";
            }
        
            
