    ISession session = ....
    IQuery query = session.CreateSQLQuery("exec LogData @Time=:time @Data=:data");
    query.SetDateTime("time", time);
    query.SetString("data", data);
    query.ExecuteUpdate();
