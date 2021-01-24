    public IList GetData() {
        var query = _session.CreateSQLQuery("exec GetTopProducingStats 
          @userId=:userId");
        query.SetParameter("userId", userId);
        var result = _session.CreateMultiQuery()
            .Add(query.AddEntity(typeof(Lure)))
            .Add(_session.CreateSQLQuery("").AddEntity(typeof(Bait)))
            .Add(_session.CreateSQLQuery("").AddEntity(typeof(Fly)))
            .List();
        return result;
    }
