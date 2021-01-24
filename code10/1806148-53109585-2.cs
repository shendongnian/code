    Student studentAlias = null;
    var studentsQueryOver= yourRepository.GetQueryOver<Student>(studentAlias);
    Exam examAlias = null;
    
    var students = studentsQueryOver
    .JoinEntityAlias(() => examAlias, () => examAlias.StudentNumber == studentAlias.Number)
    .Where(s => examAlias.Score > 70)
    .List();
