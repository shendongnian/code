        //prints the amortization of Loan
        public void LoanTable()
        {
            double monthlyPayment = GetMonthlyPayment();//calculates monthly payment
            double principalPaid = 0;
            double newBalance = 0;
            double interestPaid = 0;
            double principal = LoanAmount;
            double totalinterest = 0;
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
