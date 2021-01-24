    foreach (var grouping in StudentsAndCurrentSubjects) {
        var studentName = grouping.StudentName;
        var subjects = string.Join(", ", grouping.Subjects);
        Console.WriteLine($"{studentName}\t{subjects}");
    }
