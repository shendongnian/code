    var subQuery = QueryOver.Of<Exam>()
    	.Where(e => e.Score > 70)
        .Select(e => e.StudentNumber);
    
    subQuery.RootCriteria.Add(Restrictions.EqProperty("StudentNumber", studentsQueryOver.RootCriteria.Alias + ".Number"))
    
    //Or if root query alias variable available simply
    //subQuery.And(e => e.StudentNumber == studentAlias.Number)
    var students = studentsQueryOver
        .WithSubquery.WhereExists(subQuery)
        .List();
