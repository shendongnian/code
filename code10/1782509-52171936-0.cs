        Console.Write("Insert Age: ");
        if( true == int.TryParse(Console.ReadLine()) )
        {
           if (age < 18)
           {
              Console.WriteLine("Whoops! Looks like you are only " + age + " Year(s) old! You are too young to have your input saved.");
           }
           else
           {
              Console.WriteLine("Your input has been saved. You are " + age + " Year(s) old.");
           }
        }
        else
        {
           Console.WriteLine("This is not a number."); // Or any message you want
        }
