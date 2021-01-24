    string myConnectionString = "server=" + mysql_host + ";uid=" + mysql_user + ";" + "pwd=" + mysql_pass + ";database=" + mysql_daba;
                MySqlConnection connect;
                connect = new MySqlConnection(myConnectionString);
                string query = "SELECT * FROM Tags WHERE tagCode = @tagCode";
                AutodetectArduinoPort();
                while (true){
                    try
                    {
                        ArduPort.PortName = AutodetectArduinoPort();
                        ArduPort.Open();
                        ArduPort.Write("startmonitor");
                    }
                    catch
                    {
                        Console.WriteLine("comport did not connect.");
                    }
                    int delay;
                    string tagData = ArduPort.ReadLine();
                    ArduPort.Close();
                    Console.WriteLine(tagData);
                    connect.Open();
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.Parameters.AddWithValue("@tagCode", tagData);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string url = reader.GetValue(3).ToString();
                        delay = Convert.ToInt32(reader.GetValue(4));
                        command.Dispose();
                        Process.Start(url);
                        connect.Close();
                        Thread.Sleep(delay);
                    }
                }
