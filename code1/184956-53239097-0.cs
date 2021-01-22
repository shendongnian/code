    SqlConnection con = new SqlConnection("Data Source=192.168.1.12;Initial Catalog=Ibrahim;User ID=sa;Password=1412;");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Ibrahim.EVC_Activation_Val (Date,Dealer,Transaction_ID,Invoice_ID,Mobile_Num,Quantity_LE) values('" + DateTimePicker1.Value.ToString("yyyy/mm/dd") + "','" + Txtbx1.Text + "','" + Txtbx2.Text + "','" + Txtbx3.Text + "','" + Txtbx4.Text + "','" + Txtbx5.Text  + "')",con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                con.Close();
