     /* PSEUDOCODE */
        /* HOURLY_RATE=2.5
         * INPUT parkTime
         * parkFee = HOURLY_RATE * hours
         * OUTPUT parkFee */
    
    		bool mustRepeat = true;
            decimal parkTime = 0;  // input - time in hour eg 1.5 for 1 and a half hours 
            const decimal HOURLY_RATE = 2.50m; // HOURLY_RATE * INPUT parkTime = parkFee
            const decimal MAX_FEE = 20.00m; // MAX_FEE is set as a payment cap and ignores any extra charges incurred over 8 hours
            decimal parkFee;
            Console.WriteLine("ParkingFee1 program developed by: Ryley Copeman");
            Console.WriteLine("Please enter your total time parked in hours: Eg 1.5 or 3.0");
    		
    		while(mustRepeat)    // validate... 
            {
    			parkTime = decimal.Parse(Console.ReadLine());
    
    			if(parkTime < 0 || parkTime > 24)
    			{  		
    				Console.WriteLine("Error – Park Time out of range");
    				Console.WriteLine("Enter - Park Time between 0 and 24 (HOURS):");
    				continue;
    			}
    			
    			mustRepeat = false;
    			
    			if (parkTime > 8)
    			{
    				Console.Write("Total fee is $" + MAX_FEE);
    				break;
    			}
    			else
    			{
    				parkFee = Math.Ceiling(parkTime) * HOURLY_RATE;
    				Console.Write("Parking Fee = $" + parkFee);
    				break;
    			}
    		}
        }
    }
