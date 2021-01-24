    SqlConnection conn = new SqlConnection(@"here goes your connection string"); // select your data source goto properties and you may see your connection string over there
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from your_table_name where username ='" + textBox1.Text + "' and password='" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form2 f = new Form2();
                f.Show();
            }
            else
            {
                MessageBox.Show("please enter correct username and password", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
