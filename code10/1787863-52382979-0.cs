    public static void AddData(string inputText,string inputText1,string inputText2,string inputText3,string inputText4,string inputText5)
    {
        using (SqliteConnection db =
            new SqliteConnection("Filename=Crab.db"))
        {
            db.Open();
            SqliteCommand insertCommand = new SqliteCommand();
            insertCommand.Connection = db;
            insertCommand.CommandText = "insert into MyTable (Data,Data1,Data2,Data3,Data4,Data5) values (@Data,@Data1,@Data2,@Data3,@Data4,@Data5)";            
            insertCommand.Parameters.AddWithValue("@Data", inputText);
            insertCommand.Parameters.AddWithValue("@Data1", inputText1);
            insertCommand.Parameters.AddWithValue("@Data2", inputText2);
            insertCommand.Parameters.AddWithValue("@Data3", inputText3);
            insertCommand.Parameters.AddWithValue("@Data4", inputText4);
            insertCommand.Parameters.AddWithValue("@Data5", inputText5);
            insertCommand.ExecuteReader();
            db.Close();
        }
    }
