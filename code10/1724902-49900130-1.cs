    for (i = 0; i < 10; i++)
    {  
       Console.Write("Name: ");
       var name = Console.ReadLine();
       Console.Write("Surname: ");
       var surname = Console.ReadLine();
       Console.Write("Age: ");
       var age = Int32.Parse(Console.ReadLine());
       students.Add(new Student {Name = name, Surname = surname, Age = age});
    }
