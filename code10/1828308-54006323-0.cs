     int P1Choice;
        while (true)
        {
  	    P1Choice = int.Parse(Console.ReadLine());
            if (P1Choice == 1)
            {
                Console.WriteLine("");
                CenterWrite("You have chosen Defult Empire 1");
                break;
            }
            if (P1Choice == 2)
            {
                Console.WriteLine("");
                CenterWrite("You have chosen Defult Empire 2");
                break;
            }
            if (P1Choice == 3)
            {
                Console.WriteLine("");
                CenterWrite("You have chosen Defult Empire 3");
                break;
            }
            if (P1Choice == 4)
            {
                Console.WriteLine("");
                CenterWrite("You have chosen Defult Empire 4");
                break;
            }
            else
            {
                Console.WriteLine("");
                CenterWrite("Input Invalid, Please press the number from the corresponding choices to try again");
		break;
            }
        }
