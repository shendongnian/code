    DetachedCriteria criteria = DetachedCriteria.For<CallDisposition>()
        .Add(Expression.In("CallDispostionCode", new string[] { "AC", "CC" })
        .SetProjection(Projections.Property("CallDisposition.Id"));
    IList leadList = session.CreateCriteria(typeof(EmcLead))
        .Add(Subqueries.PropertyIn("CallDisposition.Id", criteria)).List();
