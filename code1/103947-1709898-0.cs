    var client = session
        .CreateCriteria<Client>()
        .CreateCriteria("Pers", JoinType.LeftOuterJoin)
        .Add(Expression.IdEq(1))
        .UniqueResult<Client>();
    var pj = (PersonType1)client.Pers;
