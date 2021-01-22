    Student student = new Student
    {
        FirstName = "Alex",
        LastName = "Parker"
    };
    bool isOverridden = student.GetType()
        .GetMethod(nameof(ToString))
        .IsOverridden(); // ExtMethod
    if (isOverridden)
    {
        Console.Out.WriteLine(student);
    }
