    static void Main(string[] args)
    {
        double total = 0;
        int noOfStudents = -1;
        try
        { 
            Console.WriteLine("Please enter the number of students :");
            do{
            noOfStudents = checkInputTypeInt(Console.ReadLine());
            }while(noOfStudents == -1);
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
    
    private static int checkInputTypeInt(string s)
    {
        int numericValue = -1;
            if (!int.TryParse(Console.ReadLine(), out numericValue))
                Console.WriteLine("The input must be between 0 and 1000!");
            else if (numericValue > 1000)
                {Console.WriteLine("The input must be between 0 and 1000!");
                 numericValue = -1;
        }
        return numericValue;
    }
