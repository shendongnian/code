    // This line over-writes the file if it exists, or otherwise creates it.
    using (TextWriter fileWriter = new StreamWriter(SaveFileDia.FileName, append: false))
    {
        foreach (Stud student in StudentList)
        {
            fileWriter.WriteLine($"Name: {student.Name}");
            fileWriter.WriteLine($"Subject: {student.Subject}");
            fileWriter.WriteLine($"Age: {student.age}");
            fileWriter.WriteLine($"Grade: {student.Grade}");
            fileWriter.WriteLine();
        }
    }
