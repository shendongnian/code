	void Main()
	{
		//declare variables
		decimal amount;
		decimal rate;
		int years;
		//prompt loan amount
		Console.WriteLine("Enter loan amount");
		amount = Convert.ToDecimal(Console.ReadLine());//accepts console input and assigne to variable
													   //prompt for rate
		Console.WriteLine("Enter annual interest rate");
		rate = Convert.ToDecimal(Console.ReadLine());//accepts console input and assigne to variable
													 //prompt for monhts
		Console.WriteLine("Enter number of years");
		years = Convert.ToInt32(Console.ReadLine());//accepts console input and assigne to variable
	
		Loan loan = new Loan(amount, rate, years);//create  new instance, send values to the class
	
		loan.LoanTable();
	}
	
	class Loan
	{
		//declare variables
		private decimal LoanAmount, InterestRate;
		private int LoanLength;
	
		//Constructor of Loan class that takes amount, rate and years
		public Loan(decimal amount, decimal rate, int years)
		{
			this.LoanAmount = amount;
			this.InterestRate = DecPow(1m + rate / 100m, 1m / 12m) - 1m;
			this.InterestRate.Dump();
			this.LoanLength = years;
		}
		//returns the monnthly payment
		public decimal GetMonthlyPayment()
		{
			int months = LoanLength * 12;
			return (LoanAmount * InterestRate * DecPow(1m + InterestRate, months)) / (DecPow(1m + InterestRate, months) - 1m);
		}
		//Calculates totl interterest paid and doubles it, then returns the amount
		public decimal TotalInterestPaid(decimal number1, decimal number2)
		{
			decimal TotalInterest = number1 + number2;
	
			return TotalInterest;
		}
	
		//prints the amortization of Loan
		public void LoanTable()
		{
	        decimal monthlyPayment = GetMonthlyPayment();//calculates monthly payment
	        decimal principalPaid = 0m;
	        decimal newBalance = 0m;
	        decimal interestPaid = 0m;
	        decimal principal = LoanAmount;
	        decimal totalinterest = 0m;
	        //nonth, payment amount, principal paid, interest paid, total interest paid, balance
	        Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}", "Payment Number", "Payment Amt", "Interest Paid", "Principal paid", "Balance Due", "Total Interest Paid");
	        for (int month = 1; month <= LoanLength * 12; month++)
	        {
	            // Compute amount paid and new balance for each payment period
	            totalinterest += interestPaid;
	            interestPaid = principal * InterestRate;
	            principalPaid = monthlyPayment - interestPaid;
	            newBalance = principal - principalPaid;
	            // Output the data item              
	            Console.WriteLine("{0,-10}{1,10:N2}{2,10:N2}{3,10:N2}{4,10:N2}{5,10:N2}",
	                month, monthlyPayment, interestPaid, principalPaid, newBalance, TotalInterestPaid(totalinterest, interestPaid));
	            // Update the balance
	            principal = newBalance;
	        }
		}
	
		private decimal DecPow(decimal x, decimal y) => (decimal)System.Math.Pow((double)x, (double)y);
		private decimal DecPow(decimal x, int p)
		{
			if (p == 0) return 1m;
			decimal power = 1m;
			int q = Math.Abs(p);
			for (int i = 1; i <= q; i++) power *= x;
			if (p == q)
				return power;
			return 1m / power;
		}
	}
