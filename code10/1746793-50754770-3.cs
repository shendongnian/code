    string a = Console.ReadLine();
     int age = -1;
     if(int.TryParse(a.out age))
     {
        Console.WriteLine("What is your age?" + age);
        if ((age == 0) && (age <= 0))
        {
            Console.WriteLine("Wrong input");
            System.exit(0);
        }
        else if ((age >= 1) && (age <= 6))
        {
            Console.WriteLine("you are in Preschool");
        }
        else if ((age >= 7) && (age <= 13))
        {
            Console.WriteLine("you are in Elementary School");
        }
        else if ((age >= 14) && (age <= 18))
        {
            Console.WriteLine("You are in High School");
        }
        else if ((age >= 19) && (age <= 26))
        {
            Console.WriteLine("You are probably in College");
        }
        else
        {
            Console.WriteLine("you probaby have graduated already");
        }
    }
