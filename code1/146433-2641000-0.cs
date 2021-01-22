    ProjectionList projectionList = Projections.ProjectionList();
    projectionList.Add(Projections.Property("EmployeeID"), "Id");
    projectionList.Add(Projections.Property("EmployeePosition"), "Label");
    var x = DetachedCriteria.For(Employee);
    x.SetProjection(projectionList);
    x.SetResultTransformer(Transformers.AliasToBean(SimpleType)));
    return x.GetExecutableCriteria(UnitOfWork.CurrentSession).List<SimpleType>();
