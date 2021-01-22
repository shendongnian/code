    // create a list of students and print them back out.
    StudentList list = new StudentList();
    list.Add( new Student("Bob", 1234, 2, 'A') );
    list.Add( new Student("Mary", 2345, 4, 'C') );
    foreach( Student student in list)
    {
        Console.WriteLine(student.Name);
    }
