    public Int32 GetMaxValue(String table, String column, int columnIndex)
            {
                try
                {
                    Int32 values = -1;
    
                    String query = "SELECT MAX(" + column + ") FROM " + table;
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, sQLiteConnection);
                    sQLiteCommand.ExecuteScalar();
    
                    using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
                    {
                        if (sQLiteDataReader.Read())
                        {
                            while (sQLiteDataReader.Read())
                            {
                                values = sQLiteDataReader.GetInt32(columnIndex);
                                return values;
                            }
                        }
    
                        sQLiteDataReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return -1;
            }
