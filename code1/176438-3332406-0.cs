    var query = from o in _objects.AsQueryable()
                where o.Project.Id == projectId
                select o;
    var ofType = typeof (Queryable).GetMethod("OfType").MakeGenericMethod(oType);
    var list = (IQueryable)ofType.Invoke(
                null, new object[] {query}).Cast<WritingObject>().ToList();
