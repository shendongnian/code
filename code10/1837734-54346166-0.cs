    DynamicParameters param = new DynamicParameters();
    param.Add(name: "out_variable", dbType: DbType.Decimal, direction: ParameterDirection.Output);
    ...
    database.Execute(query, param);
    var outVariable = param.Get<Decimal>("out_variable");
