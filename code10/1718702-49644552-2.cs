       /* Harrison Currie
                    * 24/03
                    * Assignment Parking Fee 1
                    * Pseudocode
                    * HOURLY RATE = 2.50
                    * PARKING FEE = HOURS *Fee
                    * MAX FEE = 20.00
                    * OUTPUT TOTAL COST TO A MAX OF $20
                    * Validate Hours are between 1-24
                    */
            //Set Constants
            const decimal HOURLY_RATE = 2.5m;
            const decimal MAX_FEE = 20.00m;
            //Declare Variables
            decimal PARKING_FEE;
            decimal HOURS =0;
            //Input
            bool valid = false;
        
            while (!valid)
            {
                Console.WriteLine("Enter hours of parking: ");
             bool parse =  decimal.TryParse(Console.ReadLine(),out HOURS);
                if (!parse)
                {
                    Console.WriteLine("Not a number.");
                    continue;
                }
                if(HOURS > 0 && HOURS <= 24)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Hours must be between 0-24");
                }
            }
            PARKING_FEE = HOURS * HOURLY_RATE;
            if (PARKING_FEE >= 20.00m) PARKING_FEE = MAX_FEE;
            else PARKING_FEE = HOURS * HOURLY_RATE;
            //Output
            Console.WriteLine("Developed By Harrison Currie");
            Console.WriteLine("The Cost Of Your Park Is $" + PARKING_FEE);
            Console.Read();
