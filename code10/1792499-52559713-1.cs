    query = "INSERT INTO \"Order\" (Name, Quantity, SUPrice, Desc, Total, Paid, Remain) VALUES (@Name,@Quantity,@SUPrice,@Description,@Total,@Paid,@Remain)"
    connection.Open();
    command = new SQLiteCommand(query, connection);
    command.Parameters.Add(new SQLiteParameter("@Name", orderDto.Name);
    command.Parameters.Add(new SQLiteParameter("@Quantity", orderDto.Quantity));
    command.Parameters.Add(new SQLiteParameter("@SUPrice" , orderDto.SUPrice));
    command.Parameters.Add(new SQLiteParameter("@Description" , orderDto.Description));
    command.Parameters.Add(new SQLiteParameter("@Total", orderDto.Total));
    command.Parameters.Add(new SQLiteParameter("@Paid" , orderDto.Paid));
    command.Parameters.Add(new SQLiteParameter("@Remain" , orderDto.Remaining));
    command.ExecuteNonQuery();
    connection.Close();
