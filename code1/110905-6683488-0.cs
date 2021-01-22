            //The fastest way to copy time            
            DateTime justDate = new DateTime(2011, 1, 1); // 1/1/2011 12:00:00AM the date you will be adding time to, time ticks = 0
            DateTime timeSource = new DateTime(1999, 2, 4, 10, 15, 30); // 2/4/1999 10:15:30AM - time tick = x
            justDate = new DateTime(justDate.Date.Ticks + timeSource.TimeOfDay.Ticks);
            Console.WriteLine(justDate); // 1/1/2011 10:15:30AM
            Console.Read();
