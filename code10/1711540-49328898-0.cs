	static void Main(string[] args)
	{
        Console.WriteLine("Please enter the number of books checked out.");
        double booksChecked = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the number of days they are overdue.");
        double daysOverdue = Convert.ToInt32(Console.ReadLine());
        // assign before printing out value
        // pass the two parameters into the function
        double totalCharge = Charge(daysOverdue, booksChecked);
		
        Console.WriteLine("Your total charge for {0} days overdue is {1:C}.", 
			daysOverdue, 
			totalCharge);
			
        Console.ReadKey();
    }	
	
    private static double Charge(double daysOverdue, double booksChecked)
    {
        if (daysOverdue <= 7)
        {
			return booksChecked * daysOverdue * .10;
        }
        else
        {
            return (booksChecked * .70) + booksChecked * (daysOverdue - 7) * (.20);
        }
    }
