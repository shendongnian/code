       Console.WriteLine("Enter start date:");
            string dateEntered1 = Console.ReadLine();
            Console.WriteLine("Enter end date:");
            string dateEntered2 = Console.ReadLine();
           
            DateTime date1 = DateTime.Parse(dateEntered1);
            DateTime date2 = DateTime.Parse(dateEntered2);
                string period = "";
                if (date1.Month == date2.Month && date1.Year == date2.Year)
                {
                    period = string.Format("{0} - {1}", date1.ToString("dd."), date2.ToString("dd.MM.yyyy"));
                }
                
                {
                    period = string.Format("{0} - {1}", date1.ToString("dd.MM.yyyy"), date2.ToString("dd.MM.yyyy"));
                }
                Console.Write(period);
