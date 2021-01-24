    var sql = "INSERT INTO table (sendDate) VALUES (";
    var parameters = input.Select((queue, i) => new MySqlParameter("@sendDate" + i.ToString(), MySqlDbType.DateTime)).ToArray();
    sql += string.Join("), (", parameters.Select(_ => _.ParameterName)) + ")";
    for (int i = 0; i < parameters.Length; i++)
    {
        parameters[i].Value = input[i].SendDate;
    }
    var command = new MySqlCommand(sql);
    command.Parameters.AddRange(parameters);
    command.ExecuteScalar();
