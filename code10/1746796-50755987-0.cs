    string text = String.Empty;
    int age;
    Console.WriteLine("What is your age?");
    if (int.TryParse(Console.ReadLine(), out age))
      {
        if (age > 26)
          text = "You probaby have graduated already.";
        else if (age < 1)
          text = "You probaby not started Preschool.";
        else if (age < 7)
          text = "You are in Preschool.";
        else if (age < 14)
          text = "You are in Elementary School.";
        else if (age < 19)
          text = "You are in High School.";
        else
          text = "You are probably in College.";
        Console.WriteLine(text);
      }
    }
