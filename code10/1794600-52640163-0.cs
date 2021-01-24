    if (!string.IsNullOrEmpty(StudentName))
        innerJoinQuery = innerJoinQuery.Where(item => item.StudentNAme == StudentName);
    if (!string.IsNullOrEmpty(StudentSurName))
        innerJoinQuery = innerJoinQuery.Where(item => item.StudentSurName == StudentSurName);
    foreach (var item in innerJoinQuery)
    ...
