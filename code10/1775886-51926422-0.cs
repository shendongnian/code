    public static void Main()
    {
        incomeTax();
        // End program
        Console.WriteLine("\n\n Hit Enter to exit.");
        Console.ReadLine();
    }
    public void incomeTax()
    {
        // Define variables
        const double incomeTax = 0.02, deduction = 10000; // Constant values - These never change
        int children; // Amount of children
        double Taxdue, totalIncomeTax; // Decimal valued variables
        // Ask total income
        Console.Write("What is your total income: ");
        bool succeed = double.TryParse(Console.ReadLine(), out totalIncomeTax);
        // Ask amount of children
        Console.Write("How many children do you have: ");
        bool succeeded = int.TryParse(Console.ReadLine(), out children);
        // If statement to check input validation.
        if (succeed && succeeded) 
        {
            // User input validation
            // Calculate Deductions
            int childTax = children * 2000; // total amount for each child
            double total_deductions = (double)deduction + childTax; // total deductions = 10k + childtax
            // Calculate User input tax takeaway (-) the total amount of deductions (Equation above)
            double taxDueCalc = totalIncomeTax - total_deductions;
            // Find 2% of the Result for the amount of Tax due
            Taxdue = taxDueCalc * incomeTax;
            // Print result
            Console.Write("You owe a total of $" + Taxdue + " tax.");
        } else {
            // Notify user of error
            Console.Write("You must enter a valid number.");
            // Redirect too first set of TryParse statements
            incomeTax();
        }
    }
