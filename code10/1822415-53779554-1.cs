    var students = new List<Student>
    {
        new Student {Name = "John", Age = 10, Grade = 98},
        new Student {Name = "Alon", Age = 10, Grade = 100}
    };
    var minGrade = students.Min(s => s.Grade);
    var maxGrade = students.Max(s => s.Grade);
            
    using (var myF = new System.IO.StreamWriter(@"C:\Users\axcel\textfolder\myFile.txt", true))
    {
        myF.WriteLine($"{"Name",-15}{"Age",-10}{"Grade",5}");
        myF.WriteLine("==============================");
        foreach (var student in students)
        {
            myF.WriteLine($"{student.Name,-15}{student.Age,-10}{student.Grade,5}");
        }
    }
