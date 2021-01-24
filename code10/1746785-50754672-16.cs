     Console.WriteLine("What is your age?");
     string a = Console.ReadLine();
     int age = -1;
     if(int.TryParse(a,out age))
     {
        Console.WriteLine("your age is : " + age);
        if ((age >= 1) && (age <= 6))
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
