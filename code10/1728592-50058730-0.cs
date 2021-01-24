    else if (txtNewUser.Text != String.Empty)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["#.Properties.Settings.ConnectionString"].ConnectionString);
            conn.Open(); //Try to open the connection to the MySql database
            //Check if there is a row with credentials entered in the form
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Count(*) FROM #.# WHERE Korisnik = '" + txtNewUser.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //Initiate a new connection string
            if (dt.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("Корисничкото име е зафатено. Ве молиме обидете внесете уникатно.", "Потсетник", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
