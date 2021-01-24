    private void button1_Click(object sender, EventArgs e)
    {
        {
            string commandText = "Select * From User_Registration where UserID = @UserID  and Password = @Password ";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\mohamma ali\Documents\Visual Studio 2015\Projects\WindowsFormsApplication4\WindowsFormsApplication4\MyLib_DB.mdf ;Integrated Security=True;Connect Timeout=30"))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@UserID", username_textbox.Text.Trim());
                command.Parameters.AddWithValue("@Password", password_text.Text.Trim());
                try
                {
                    connection.Open();
                    sda.SelectCommand = command;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        mainmenu main = new mainmenu();
                        this.Hide();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Check usename and password");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
