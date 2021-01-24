    query = "INSERT INTO \"Order\" (Name, Quantity, SUPrice, Desc, Total, Paid, Remain) VALUES ( '" + orderDto.Name + "', '" + orderDto.Quantity + "', '" + orderDto.SUPrice + "', '" + orderDto.Description + "', '" + orderDto.Total + "', '" + orderDto.Paid + "', '" + orderDto.Remaining  + "')";
    connection.Open();
    command = new SQLiteCommand(query, connection);
    command.ExecuteNonQuery();
    connection.Close();
