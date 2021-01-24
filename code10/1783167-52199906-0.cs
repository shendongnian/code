    // char: we actually input a single character, not string
    char input = '\0'; // initialize to make compiler happy
    // keep on asking until success
    while (true) {
      Console.WriteLine("Enter a, b, c or d:"); 
      // ReadKey: We want a single character, not a string
      input = Console.ReadKey();   
      // input is valid if it's in ['a'..'d'] range
      if (input >= 'a' && input <= 'd') {
        Console.WriteLine("Success");
 
        break;
      }
      Console.WriteLine("Try again"); 
    }
