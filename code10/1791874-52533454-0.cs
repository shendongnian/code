     using (SQLiteConnection c =
                new SQLiteConnection("data source=" + Datos.dataBase +
                                     "\\bdDisplay.sqlite;Version=3;New=False;Compress=True;"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    var effect = cmd.ExecuteNonQuery();
                    return effect > 0;
                }
            }
