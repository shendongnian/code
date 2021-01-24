            DateTime date1 = new DateTime();
            DateTime date2 = new DateTime();
    //while not valid input dates format...
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Enter start date:");
                string dateEntered1 = Console.ReadLine();
                Console.WriteLine("Enter end date:");
                string dateEntered2 = Console.ReadLine();
               
                 bool isvalidDate1 = DateTime.TryParse(dateEntered1,out date1);
                bool isvalidDate2 = DateTime.TryParse(dateEntered2,out date2);
    //check if date parsing was sucess
                if(isvalidDate1 && isvalidDate2)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Dates entered is in incorrect format!");
                }
            }
            string period = "";
            if (date1.Month == date2.Month && date1.Year == date2.Year)
            {
                period = string.Format("{0} - {1}", date1.ToString("dd."), date2.ToString("dd.MM.yyyy"));
            }
            
            {
                period = string.Format("{0} - {1}", date1.ToString("dd.MM.yyyy"), date2.ToString("dd.MM.yyyy"));
            }
            Console.Write(period);
            Console.Read();
