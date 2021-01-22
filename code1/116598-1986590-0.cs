            System.Console.WriteLine("Enter a date and time.");
            string strDateTime = System.Console.ReadLine();
            System.DateTime localDateTime;
            try {
                localDateTime = System.DateTime.Parse(strDateTime);
            }
            catch (System.FormatException) {
                System.Console.WriteLine("Invalid format.");
                return;
            }
            System.DateTime univDateTime = localDateTime.ToUniversalTime();
            System.Console.WriteLine("{0} local time is {1} universal time.",
                                     localDateTime,
                                     univDateTime); 
            
            System.Console.WriteLine("Enter a date and time in universal time.");
            strDateTime = System.Console.ReadLine();
            try {
                univDateTime = System.DateTime.Parse(strDateTime);
            }
            catch (System.FormatException) {
                System.Console.WriteLine("Invalid format.");
                return;
            }
            localDateTime = univDateTime.ToLocalTime();
            System.Console.WriteLine("{0} universal time is {1} local time.",
                                     univDateTime,
                                     localDateTime); 
