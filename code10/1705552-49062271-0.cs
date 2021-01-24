    Console.Write("Enter the number of tests: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int sum = 0, i = 0, score = 0;
    int[] scores = new int[n];
    Console.WriteLine("----------------------------------------");
    do {
        Console.WriteLine("Please enter the test score #" + (i + 1));
        score = Convert.ToInt32(Console.ReadLine());
        if (score < 0) {
            Console.WriteLine("Please enter a value greater or equal to 0");
        }
        else if (score > 100)
        {
            Console.WriteLine("Please enter a value less or equal to 100");
        }
        else {
            scores[i] = score;
        }
        i++;
    } while (i < n);
    foreach (int d in scores) {
        sum += d;
    }
    Console.WriteLine("The sum of all the scores is {0}", sum);
    Console.ReadLine();
