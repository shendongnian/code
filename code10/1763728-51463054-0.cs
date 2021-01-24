    private void OPCode()
            {
                try
                {
                    //keep your connections close to the vest (local)
                    using (SqlConnection connection = new SqlConnection())
                    //a using block ensures that your objects are closed and disposed 
                    //even if there is an error
                    {
                        using (SqlCommand cmd2 = new SqlCommand("SELECT BookAvailability  FROM Book_list WHERE BookName = @BookName", connection))
                        {
                            //Always use parameters to protect from sql injection
                            //Also it is easier than fooling with the single quotes etc.
                            //If you are referring to a TextBox you need to provide what property is
                            //being accessed. I am not in a WPF right now and not sure if .Text
                            //is correct; may be .Content
                            //You need to check your database for correct data type and field size
                            cmd2.Parameters.Add("@BookName", SqlDbType.VarChar, 100).Value = TextBoxBookName.Text;
                            //A select statement is not a non-query
                            //You don't appear to be using the data table or data adapter
                            //so dump them extra objects just slow things dowm
                            connection.Open();
                            var returnVal = cmd2.ExecuteScalar() ?? 0;
                            if ((int)returnVal > 0)
                            {
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO issue_book VALUES(@SearchMembers etc", connection))
                                {
                                    //set up the parameters for this command just like the sample above
                                    cmd.Parameters.Add("@SearchMembers", SqlDbType.VarChar, 100).Value = TextBoxSearchMembers.Text;
                                    cmd.ExecuteNonQuery();
                                }
                                using (SqlCommand cmd1 = new SqlCommand("UPDATE Book_list SET BookAvailability = BookAvailability-1 WHERE BookName = @BoxBookName;", connection))
                                {
                                    cmd1.Parameters.Add("@BoxBookName", SqlDbType.VarChar, 100);
                                    cmd1.ExecuteNonQuery();
                                }
                                MessageBox.Show("success");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Book not available");
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
