    SqlDataAdapter SDA = new SqlDataAdapter("Select Name,Phone from "+textBox2.Text+"' where Name='" + textBox1.Text + "' ", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                textBox3.Text = (dt.Rows[0][0].ToString());
            }
