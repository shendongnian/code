    public List<students> SearchStudents(students search)
    {
        var query = db.students;
        if (!string.IsNullOrWhiteSpace(search.enrollmentNumber))
        {
            query = query.Where(s => s.enrollmentNumber == search.enrollmentNumber);
        }
        if (search.enrollmentDate != DateTime.MinValue)
        {
            query = query.Where(s => s.enrollmentDate == search.enrollmentDate);
        }
        if (!string.IsNullOrWhiteSpace(search.enrollmentType))
        {
            query = query.Where(s => s.enrollmentType == search.enrollmentType);
        }
        if (!string.IsNullOrWhiteSpace(search.className))
        {
            query = query.Where(s => s.className == search.className);
        }
        return query.Select(stud => new Search
                                    {
                                        enrollmentNumber= stud.enrollmentNumber,
                                        enrollmentDate = stud.enrollmentDate,
                                        enrollmentType = stud.enrollmentType,                                    
                                        Name = stud.Name,
                                        className=stud.className,                                                                      
                                        Description = stud.Description
                                    })
                    .ToList();
    }
