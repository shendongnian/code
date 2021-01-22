    string message = "This is a test message.";
    string nonLetters = new string(message.Where(x => !Char.IsLetter(x)).ToArray());
    Console.WriteLine("There are {0} non-characters in \"{1}\" and they are: {2}",
         nonLetters.Length,
         message,
         nonLetters);
