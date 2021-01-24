    string answer = string.Empty;
    using (OleDbConnection conn = new OleDbConnection(connString))
    {
        conn.Open();
        Console.WriteLine("Connection Is Established");
        string SQL = "SELECT * FROM [qSales]";
        using (OleDbCommand comm = new OleDbCommand(SQL, conn))
        {
            using (OleDbDataReader reader = comm.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var firstCol = reader[0]?.ToString() ?? string.empty;
                        var secCol = reader[1]?.ToString() ?? string.empty;
                        var thirdCol = reader[2]?.ToString() ?? string.empty;
                        answer += string.Format(@"{0}:\t{1}\t{2}\n", firstCol, secCol, thirdCol);
                    }
                }
            }
        }
        conn.Close();
    }
    Console.WriteLine(answer);
    Console.WriteLine("Hit ENTER For Exit");
    Console.ReadLine();
