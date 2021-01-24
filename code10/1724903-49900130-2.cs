    Console.Write("Name of student you are looking for: ");
    string name = Console.ReadLine();
    var foundStudent = students.FirstOrDefault(s => s.Name.Equals(name));
    if(foundStudent != null)
    {
       var index = students.IndexOf(foundStudent);
       Console.Write("Student"+foundStudent.Name+" is located at"+index+" place.");
    }
    else
    {
       Console.WriteLine($"No student for name {name} found");
    }
