    float Sqrt(int x)
    {
        if (x > 0)
        {
            // Calculate square root
            return Math.Sqrt(x);
        }
        else
        {
            // Ignore imaginary numbers for now, use absolute value
            Console.WriteLine("Don't do that!");
            // Note there is no return statement here
        }
    }
