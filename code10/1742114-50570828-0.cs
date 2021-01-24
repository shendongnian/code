    private void btnregister_Click(object sender, EventArgs e)
                {
                    var insertedId = 0;
                    try
                    {
                        cn.Open();
    
                        cmd = new SqlCommand(
                            "INSERT INTO register (FirstName, LastName) output inserted.Id VALUES(@FirstName, @LastName)", cn);
                        cmd.Parameters.AddWithValue("@FirstName", txtfname.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtlname.Text);
                        var result = cmd.ExecuteScalar();
                        try
                        {
                            insertedId = (int) result;
                        }
                        catch
                        {
                            throw new Exception("No rows were added");
                        }
                        MessageBox.Show("saved");
                        cn.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot Save");
                    }
                }
