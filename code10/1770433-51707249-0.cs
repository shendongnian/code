    DateTime limitDate = new DateTime(2000, 1, 1);
    IEnumerable<Student> students = GetAllStudents();
    List<Address> addresses = new List<Address>();
    foreach (Student student in students)
    {
        if (student.Birthday < limitDate)
           addresses.Add(student.Address);
    }
