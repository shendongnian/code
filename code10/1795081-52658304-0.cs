      using (var stream = new FileStream(@"C:\data.csv",FileMode.Open, FileAccess.Read, 
                FileShare.ReadWrite)
                {
                  using(var reader = new StreamReader(stream))
                    {
                        List<string> listA = new List<string>();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            string querynew = "INSERT INTO new_jobs"
                                      + "(job_reference,status)" 
                                      + "VALUES (?jobNo, ?strClientName)";
                                MySqlCommand cmd = connection.CreateCommand();
                        cmd.CommandText= querynew;
                                cmd.Parameters.Add("?jobNo", MySqlDbType.VarChar).Value = 
                                          (values[0]);
                                cmd.Parameters.Add("?strClientName", MySqlDbType.VarChar).Value =(values[1]);
                        cmd.ExecuteNonQuery(); 
                       56 filemove(); <-- error trigger line
                        }
                    }
                 }
