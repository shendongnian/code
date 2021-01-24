     conn.Open();
            using (StreamReader reader = new StreamReader(NazwaCSV.Text))
            {
                reader.ReadLine();
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] pola = line.Split(';');
                    using (SqlCommand sc = new SqlCommand())
                    {
                        sc.CommandText = "INSERT INTO Wyscig(Pozycja,nrTAG,cTAG,czas,dat) VALUES (@poz,@tagid,@tagcount,@data,@odczyt)";
                        sc.Connection = conn;
                        sc.Parameters.Add(new SqlParameter("@poz", pola[0]));
                        sc.Parameters.Add(new SqlParameter("@tagid", pola[1]));
                        sc.Parameters.Add(new SqlParameter("@tagcount", pola[2]));
                        sc.Parameters.Add(new SqlParameter("@data", pola[3]));
                        sc.Parameters.Add(new SqlParameter("@odczyt", pola[4]));
                        sc.ExecuteNonQuery();
                        
                    }
                }
            }
            conn.Close();
