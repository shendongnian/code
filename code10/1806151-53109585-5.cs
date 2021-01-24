    Exam examAlias = null;
    studentsQueryOver.RootCriteria
    .CreateEntityAlias(
            nameof(examAlias),
            Restrictions.EqProperty("examAlias.StudentNumber", studentsQueryOver.RootCriteria.Alias + ".Number"),
            JoinType.LeftOuterJoin,
            typeof(Exam).FullName);
    var students = studentsQueryOver
    .Where(s => examAlias.Score > 70)
    .List();
