    var students = new List<(string name, int age, int grade)>()
    {
        ("John", 21, 98),
        ("Alon", 45, 100)
    };
    
    students.Add(("Alice", 35, 99));
    
    using (var writer = new StreamWriter("myFile.txt"))
    {
        writer.WriteLine(string.Join("\t", "Name", "Age", "Grade"));
                    
        foreach(var student in students)
        {
            writer.WriteLine(string.Join("\t", student.name, student.age, student.grade));
        }
    }
