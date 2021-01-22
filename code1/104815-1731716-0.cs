    int result;
    bool isInt = Int32.TryParse(Console.ReadLine(), out result);
    if (!isInt) {
      Console.WriteLine("Your input is not an integer number.");
      continue;
    }
    
    answers[i] = result;
