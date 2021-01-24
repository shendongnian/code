                using (XmlTextReader reader = new XmlTextReader("D:\\test.xml"))
                {
                    while (reader.Read())
                    {
                        SqlCommand insertCommand = new SqlCommand("spInsertimiListes", conn);
                        if (reader.IsStartElement("Name_details"))
                        {
                            first_name = " ";
                            middle_name = " ";
                            surname = " ";
                            gender = " ";
                            occ_title = " ";
                            while(reader.Read() && reader.IsStartElement())
                            {
                                switch(reader.Name)
                                {
                                    case "FirstName":
                                        first_name = reader.ReadString();
                                        break;
                                    case "MiddleName":
                                        middle_name = reader.ReadString();
                                        break;
                                    case "Surname":
                                        surname = reader.ReadString();
                                        break;
                                    case "Gender":
                                        gender = reader.ReadString();
                                        break;
                                    case "OccTitle":
                                        occ_title = reader.ReadString();
                                        break;
                                    default:
                                        throw new InvalidExpressionException("Unexpected tag");
                                }
                                reader.ReadEndElement();
                            }
                        }
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("FirstName", first_name);
                        insertCommand.Parameters.AddWithValue("MiddleName", middle_name);
                        insertCommand.Parameters.AddWithValue("Surname", surname);
                        insertCommand.Parameters.AddWithValue("Gender", gender);
                        insertCommand.Parameters.AddWithValue("OccTitle", occ_title);
                        if (!((first_name == " " && surname == " " && middle_name == " " && gender == " " && occ_title == " ")))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
