              using (XmlTextReader reader = new XmlTextReader("D:\\test.xml"))
                    {
                        reader.ReadToFollowing("Person"); // it will read the first node
                        if (reader.ReadToDescendant("Name_details")) // it will read the first descendent of Person
                        {
                            do
                            {
                                SqlCommand insertCommand = new SqlCommand("spInsertimiListes", conn);
    
                                if (reader.IsStartElement())
                                {
                                    first_name = " ";
                                    middle_name = " ";
                                    surname = " ";
                                    gender = " ";
                                    occ_title = " ";
    
                                    foreach (var item in reader.Name)
                                    {
                                        if (reader.Name == "FirstName")
                                        {
                                            first_name = reader.ReadString();
                                        }
                                        else if (reader.Name == "MiddleName")
                                        {
                                            middle_name = reader.ReadString();
                                        }
                                        else if (reader.Name == "Surname")
                                        {
                                            surname = reader.ReadString();
                                        }
                                        else if (reader.Name == "Gender")
                                        {
                                            gender = reader.ReadString();
                                        }
                                        else if (reader.Name == "OccTitle")
                                        {
                                            occ_title = reader.ReadString();
                                        }
                                    }
                                }
    
                                insertCommand.CommandType = CommandType.StoredProcedure;
    
                                insertCommand.Parameters.AddWithValue("FirstName", first_name);
                                insertCommand.Parameters.AddWithValue("MiddleName", middle_name);
                                insertCommand.Parameters.AddWithValue("Surname", surname);
                                insertCommand.Parameters.AddWithValue("Gender", gender);
                                insertCommand.Parameters.AddWithValue("OccTitle", occ_title);
    
                                if (!((first_name == " " & surname == " " & middle_name == " " & gender == " " & occ_title == " ")))
                                {
                                    insertCommand.ExecuteNonQuery();
                                }
                            } while (reader.ReadToNextSibling("Name_details")); // it will read next descendent of person
                        }
                    }
