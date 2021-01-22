    string message = "This is a test message.";
    var nonLetters = message.Where(x => !Char.IsLetter(x));
    Console.WriteLine("There are {0} non-characters in \"{1}\" and they are: {2}",
         nonLetters.Count(),
         message,
         new string(nonLetters.ToArray()));
