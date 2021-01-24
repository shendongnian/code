    double average = 0;
    double sum = 0;
    int numberOfTests = 4;
    for (int count = 0; count < numberOfTests; count++) // Start the count from 0-4
    {
        Console.WriteLine($"Please enter test score {count}");
        testScore = double.Parse(Console.ReadLine());
        
        //get the total
        sum = sum + testScore; //or sum += testScore;
    }
    //Calculate and display (needs to be outside or else gets printed 4 times)
    Console.WriteLine("The average of your test score is : " sum / numberOfTests);
