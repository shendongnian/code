    // This line over-writes the file if it exists, or otherwise creates it.
    using (TextWriter fileWriter = new StreamWriter(SaveFileDia.FileName, append: false))
    using (TextWriter textWriter = new StringWriter())
    {
        textWriter.WriteLine($"Name: {student.Name}");
        textWriter.WriteLine($"Subject: {student.Subject}");
        textWriter.WriteLine($"Age: {student.age}");
        textWriter.WriteLine($"Grade: {student.Grade}");
        textWriter.WriteLine();
        string StudentInfoHolder = textWriter.ToString();
        Clipboard.SetText(StudentInfoHolder);
        fileWriter.Write(StudentInfoHolder);
    }
