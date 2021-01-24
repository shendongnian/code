		string selectsql =	@"SELECT  
								G.Nume
							,	G.Prenume
							,	G.Telefon
							,	G.NumarInsotitori
							,	G.ClientID
							,	G.Sex
							,	(SELECT E.Nume FROM Excursii E WHERE E.ExcursieID LIKE G.ExcursieID) AS Excursie
							FROM 
								Clienti G 
							WHERE 
								G.CNP LIKE @cnp";
								
		using(SqlConnection sqlCon = new SqlConnection(connectionString))
		using(SqlCommand cmd = new SqlCommand(selectsql, sqlCon) )
		using(SqlDataReader read = cmd.ExecuteReader())
		{
			cmd.Parameters.AddWithValue("@cnp", comboBox2.Text);		
					
			sqlCon.Open();
					
			while(read.Read())
			{
				textBox1.Text = (read["Nume"].ToString());
				textBox2.Text = (read["Prenume"].ToString());
				textBox3.Text = (read["Telefon"].ToString());
				textBox4.Text = (read["NumarInsotitori"].ToString());
				textBox5.Text = (read["ClientID"].ToString());
				comboBox1.Text = (read["Excursie"].ToString());
				string sex = (read["Sex"].ToString());
				if (sex == "M")
				{
					checkBox1.Checked = true;
					checkBox2.Checked = false;
				}
				else
				{
					checkBox2.Checked = true;
					checkBox1.Checked = false;
				}
			
			}
		}
