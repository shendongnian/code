    int answer = 0;
    while(answer == 0)
    {
        try
        {
            var inputAnswer = Convert.ToInt32(Console.ReadLine());
            answer = inputAnswer;
        }catch
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
