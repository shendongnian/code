        var detached = DetachedCriteria.For<Document>()
            .CreateCriteria("UserList")
            .SetProjection(Projections.Id())
            .Add(Restrictions.IdEq(obj.Id));
        IList<Document> results = UnitOfWork.CurrentSession.CreateCriteria(typeof(Document),"s")
            .CreateAlias("s.User","u")
            .Add(Restrictions.Or(Restrictions.Eq("u.Id", obj.Id), Subqueries.Exists(detached)))
            .SetFirstResult(pageSize * page)
            .SetMaxResults(pageSize)
            .List<Document>();
