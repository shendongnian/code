     using (SqlDataReader oReader = command.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                if (oReader["comments1"].ToString() == "0")
                                {
                                    MessageBox.Show("CHECK THE COMMENTS AND THE GIVEN VALUE");
                                    ;
                                }
                                else
                                {
                                    MessageBox.Show("Inserted");
                                    ClearTextBoxes(this);
                                    button2.Enabled = false;
                                }
    
    
    
                            }
