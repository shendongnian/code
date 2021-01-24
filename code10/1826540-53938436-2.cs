    Console.WriteLine("Enter age between 0 and 100");
    int age = 0;
    while(!int.TryParse(Console.ReadLine(), out  age) || age < 0 || age > 100)
       Console.WriteLine("You had one job, enter a correct age between 0 and 100 (inclusively)");
    
    student.Age = age;
