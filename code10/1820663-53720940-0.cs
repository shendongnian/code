    var col = new object[] { new { Column1 = "Test", Column2 = 1 }, new { Column1 = "2nd row", Column2 = 2 }, ... };
    IDbDataParameter p = command.CreateParameter();
    p.DbType = DbType.String;
    p.ParameterName = "mytable";
    p.Value = JsonConvert.SerializeObject(col); // NewtonSoft 
    command.Parameters.Add(p);
    command.CommandText = "SELECT * FROM OPENJSON(@mytable) WITH (Column1 nvarchar(max), Column2 int)";
