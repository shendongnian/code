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
            else
            {
				con.Close();
				
                var sqlCommand = "INSERT INTO #.#" +
					"(Korisnik, Lozinka, Vid_Smetka, email, user_function, full_name) " +
					"VALUES ('" + this.txtNewUser.Text + "', '" + this.txtNewPassword.Text + "', '" + Vid_Smetka + "', " +
					"'" + this.txtNewEmail.Text + "', '" + this.comboNewFunction.Text + "', '" + this.txtNewFullname.Text + "');";
				//Initiate a new connection string
				try
				{
					using (MySqlConnection con = new MySqlConnection(conString))
					{
						MySqlCommand cmdDatabase = new MySqlCommand(sqlCommand, con);
						con.Open();
						MySqlDataReader myReader;
						myReader = cmdDatabase.ExecuteReader();
						dataGridView1.DataSource = loadData().Tables[0];
						MessageBox.Show("Зачувано.", "Известување", MessageBoxButtons.OK, MessageBoxIcon.Information);
						panelNew.Visible = false;
						
						con.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
