    int ans = 6;
    Console.WriteLine("Enter a number between 1 and 10");
    //taking integer input from user
    int input = Convert.ToInt32(Console.ReadLine());
    //now checking user input with selected answere
    if(ans == input)//true, when user predicts correct number
    {
        Console.WriteLine("Congratulations!!!");
    }
    else if(input < ans)//true, when user predicted number < actual number
    {
        Console.WriteLine("The actual answer is less than what you entered");
    }
    else//true, when both above conditions are false
    {
        Console.WriteLine("The actual answer is greater than what you entered");
    }
