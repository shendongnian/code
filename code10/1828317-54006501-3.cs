    while (true) {
        int P1Choice = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        if (1 <= P1Choice && P1Choice <= 4) {
            CenterWrite("You have chosen Default Empire " + P1Choice);
        } else {
            CenterWrite("Input Invalid, Please press the number from the corresponding choices to try again");
        }
    }
