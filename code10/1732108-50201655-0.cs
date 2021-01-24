    Console.WriteLine("\nWhat is your guess?");
    string userGuess = Console.ReadLine();
    // Storing each individual character from userGuess to currentGuessArray
    for (int i = 0; i < numbersArray.Length; i++)
    {
         // You have to use ToString() method to make sure that the digits will be
         // converted to integer not their ASCI values
         currentGuessArray[i] = Convert.ToInt32(userGuess[i].ToString());
    }
