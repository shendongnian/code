        // Create a StringWriter to hold the data, and write each line.
        var sWriter = new StringWriter();
        foreach (Stud student in StudentList)
        {
            sWriter.WriteLine("Name: " + student.Name);
            sWriter.WriteLine("Subject: " + student.Subject);
            sWriter.WriteLine("Age: " + student.age);
            sWriter.WriteLine("Grade: " + student.Grade);
        }
        // write the data to the file
        StudentInfoHolder = sWriter.ToString();
        File.WriteAllText(SaveFileDia.FileName, StudentInfoHolder);
