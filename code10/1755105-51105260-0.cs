    // These should be the min/max lottery numbers
    int min = 1;
    int max = 100;
    int numberOfLotteryNumbers = 6;
    // Renamed for clarity
    int[] lotteryNumbers = new int[numberOfLotteryNumbers];
    int[] userNumbers = new int[numberOfLotteryNumbers];
    // Step 1 - generate numbers
    for (int i = 0; i < lotteryNumbers.Length; i++) {
        int randomNumber;
        do {
           randomNumber = randnum.Next(min, max);
        } while (isValueInArray(randomNumber, numbers));
        lotteryNumbers[i] = randomNumber;
    }
    
    // Step 2 - get numbers from user
    for (int i = 0; i < lottery.Length; i++) {
        int userInput;
        do {
            userInput = int.Parse(Console.ReadLine());
        } while (userInput < min || userInput > max || isValueInArray(userInput, lottery));
        userNumbers[i] = userInput;
    }
    
    // Step 3 - calc matches
    int matches = 0;
    for (int i = 0; i < userNumbers.Length; i++) {
        if (isValueInArray(userNumbers[i], lotteryNumbers) {
            matches += 1;
        }
    }
    
    // Step 4 - print results
    Console.WriteLine("There are {0} matches.", matches);
