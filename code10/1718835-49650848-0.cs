     DateTime date1 = DateTime.Now;
                DateTime date2 = date1.AddDays(35);
                string period = "";
                if (date1.Month == date2.Month && date1.Year == date2.Year)
                {
                    period = string.Format("{0} - {1}", date1.ToString("dd."), date2.ToString("dd.MM.yyyy"));
                }
                
                {
                    period = string.Format("{0} - {1}", date1.ToString("dd.MM.yyyy"), date2.ToString("dd.MM.yyyy"));
                }
                Console.Write(period);
