            String s = "";
            DateTime date = new DateTime(2017, 1, 1);
            for (int i = 0; i < 14; i++)
            {
                date = date.AddDays(1);
                DateTime thu = date.AddDays(-(int)(date.AddDays(-5).DayOfWeek) -1);
                DateTime mon = date.AddDays(-(int)(date.AddDays(-2).DayOfWeek) -1);
                s += date.ToString() + " - Thu: " + thu.ToString() + " - Mon: " + mon.ToString() + "\r\n";
            }
            Console.WriteLine(s);
