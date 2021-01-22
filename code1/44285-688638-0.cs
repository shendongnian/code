    Session.CreateCriteria(typeof(Entity))
        .Add(Restrictions.Eq("EntityId", entityId))
        .CreateAlias("Address", "Address")
        .Add(Restrictions.Le("Address.StartDate", effectiveDate))
        .Add(Restrictions.Disjunction()
            .Add(Restrictions.IsNull("Address.EndDate"))
            .Add(Restrictions.Ge("Address.EndDate", effectiveDate)))
        .UniqueResult<Entity>();
