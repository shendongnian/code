                   cmd.CommandText = "Select * from Emp";
                   cmd.CommandType = CommandType.Text;
                   cmd.Connection = con;
                   DartaReader dr;
                   dr = cmd.ExecuteReader();
                   while (dr.Read())
                   {//textbox contain the id or name which you want to check in table
                        if (dr[0].ToString() == textBox1.Text)
                        {
                            MessageBox.Show("Record is Already Exist");
                            con.Close(); 
                            break;
                        }
                  }
