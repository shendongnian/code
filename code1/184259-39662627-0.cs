           DateTime Today = new DateTime( DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
           DateTime cc = new DateTime(2016, 9, 1).AddMonths(1).AddDays(-1);
			   
			Console.WriteLine(Today.ToString());
            Console.WriteLine(cc.ToString());
		
		
            if (Today <=  cc)
            {
				Console.WriteLine("Ok");
            }
            else
            {
				Console.WriteLine("Card Expiry Date is not valid ");
            }
