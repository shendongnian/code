            string cn = "Data Source=.;Initial Catalog=mvrdatabase;Integrated Security=True";
            SqlConnection con = new SqlConnection(cn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count (*) from logintable where username ='" + txt_uname.Text + "'and password='" + txt_pass.Text + "'", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (i == 1)
            {
                Form2 f2 = new Form2();
                MessageBox.Show("User login successfully........");
                this.Hide();
                f2.Show();
            }
            else
            {
                MessageBox.Show("INCORRECT USERID AND PASSWORD", "Error");
            }
        }
