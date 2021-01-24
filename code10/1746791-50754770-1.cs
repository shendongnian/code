    int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What is your age?" + age);
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
