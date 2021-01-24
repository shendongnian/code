    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;
        try
        {
            var textBox1 = textBox1.Text;
            var textBox2 = textBox2.Text;
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dienynas.mdf;Integrated Security=True;");
            conn.Open();
            cmd = new SqlCommand("select * from users", conn);
            sdr = cmd.ExecuteReader();
            
            int id = -1;
            while (sdr.Read())
            {
                var text0 = sdr[0].ToString();
                var text1 = sdr[1].ToString();
                
                // NOTE: You could add the string comparison type here as well
                if (text0.Equals(textBox1) && text1.Equals(textBox2))
                {
                    id = (int)sdr[0];
                    break;
                }
            }
            if (id == -1)
            {
                MessageBox.Show("Password for this user is incorrect");
            }
            else
            {
                Form1 frm = new Form1(id);
                Hide();
                frm.Show();
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            sdr?.Dispose();
            cmd?.Dispose();
            conn?.Dispose();
        }
    }
