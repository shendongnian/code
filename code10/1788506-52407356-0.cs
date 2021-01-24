    void OldOnesToFile(List<Student> students)
    {
        List<string> lines = new List<string>();
        foreach (Student student in students)
        {
            if (student.Course > 1)
                lines.Add(String.Format(...));
        }
        File.WriteAllLines(@"senbuviai.txt", lines);
    }
