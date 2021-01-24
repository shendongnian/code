    static void Main(string[] args)
    {
        double total = 0;
        int noOfStudents = 0;
        try
        {
            Console.WriteLine("Please enter the number of students :");
            noOfStudents = checkInputTypeInt();
            Console.WriteLine("Enter the students(" + noOfStudents + ") money!");
    
            for (int i = 0; i <= noOfStudents - 1; i++)
            {
                double money = checkInputTypeDouble(Console.ReadLine());
                total += money;
            }
            double dividedTotal = total / noOfStudents;
            Console.WriteLine("Total divided by " + noOfStudents + " is $ " + dividedTotal.ToString("F2"));
            Console.ReadKey();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private static int checkInputTypeInt()
    {
        int numericValue = 0;
        bool done = false;
        while (!done)
        {
            if (!int.TryParse(Console.ReadLine(), out numericValue))
                Console.WriteLine("The input must be between 0 and 1000!");
            else if (numericValue > 100)
                Console.WriteLine("The input must be between 0 and 1000!");
            else
                done = true;
        }
        return numericValue;
    }
