     MySQLiteConn = new SQLiteConnection("Data Source=" + fileName +
                        "; Compress = TRUE;");
    SQLiteCommand cmd = MySQLiteConn.CreateCommand();
    
    
                SQLiteDataAdapter dr = new SQLiteDataAdapter(cmd);
                SQLiteDataAdapter adapter;
                try
                {
                    cmd.CommandText = "SELECT * FROM teklif";
                    adapter = new SQLiteDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Retrieval of Table Failed. " + ex.Message);
                    return -1;
                }
