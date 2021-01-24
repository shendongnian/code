    if (!string.IsNullOrEmpty(StudentName))
        innerJoinQuery = innerJoinQuery.Where(item => item.StudentName == StudentName);
    if (!string.IsNullOrEmpty(StudentSurname))
        innerJoinQuery = innerJoinQuery.Where(item => item.StudentSurname == StudentSurname);
    foreach (var item in innerJoinQuery)
    ...
