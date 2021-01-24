    query.CreateEntityAlias("otherAlias",
        Restrictions.EqProperty("rootAlias.OtherId", "otherAlias.ID"),
        JoinType.InnerJoin,
        "OtherDBTable"
    );
