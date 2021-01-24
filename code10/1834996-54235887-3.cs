            var date1 = DateTime.Now;
            var date2 = DateTime.Now.AddDays(20);
            var days = (date2.Date - date1.Date).Days; // number of days between
            Random rand = new Random();
            int randDays;
            DateTime randomDate;
            if (days < 0)
            {
                randDays = rand.Next(1, Math.Abs(days) - 1);
                randomDate = date2.AddDays(randDays);
            }
            else
            {
                randDays = rand.Next(1, days - 1);
                randomDate = date1.AddDays(randDays);
            }
            
