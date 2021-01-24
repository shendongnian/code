    double average = 0;
    double sum = 0;
    int numberOfTests = 4;
    for (int count = 0; count < numberOfTests; count++) // Start the count from 0-4
    {
        Console.WriteLine("Please enter test score " + count); //Console.WriteLine($"Please enter test score {count}");
        double testScore = 0;
        while(!double.TryParse(Console.ReadLine(), out testScore))
        {
            Console.WriteLine("Enter a valid number");
        }
        
        //get the total
        sum = sum + testScore; //or sum += testScore;
    }
    //Calculate and display (needs to be outside or else gets printed 4 times)
    Console.WriteLine("The average of your test score is : " sum / numberOfTests);
