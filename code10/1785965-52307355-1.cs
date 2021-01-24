        Form2 dash = new Form2();
        Form10 userdash = new Form10();
        DBConnection.DBC_Connection db = new DBConnection.DBC_Connection();
        DBConnection.Login lg = new DBConnection.Login();
        SqlDataAdapter sda = new SqlDataAdapter("select *, Type from Login where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", db.creatconnection());
        DataTable dta = new DataTable();
        sda.Fill(dta);
        if(dta.Rows.Count > 0)
        {
            if(dta.Rows[0][0].ToString() == "1" && dta.Rows[0]["Type"].ToString() == "Admin")
            {
                this.Hide();
                dash.Show();
            }
            else
            {
                this.Hide();
                userdash.Show();
            }
        }
        else
        {
            MessageBox.Show("Invalid Login try checking Useraname Or Password !" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
