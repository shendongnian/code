    Exam examAlias = null;
    var students = studentsQueryOver.RootCriteria
    .CreateEntityAlias(
            nameof(examAlias),
            Restrictions.EqProperty("examAlias.StudentNumber", studentsQueryOver.RootCriteria.Alias + ".Number"),
            JoinType.LeftOuterJoin,
            typeof(Exam).FullName)
    .Where(s => examAlias.Score > 70)
    .List();
