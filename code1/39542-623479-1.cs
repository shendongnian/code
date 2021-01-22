     static DateTime LastOccurenceOfDay(DateTime dt, DayOfWeek dow)
             {
                 //set start of loop
                 DateTime looperDate = new DateTime(dt.Year, dt.Month, 1); 
                 //initialze return value
                 DateTime returnDate = dt;
                 //loop until the month is over
                 while (looperDate.Month == dt.Month)
                 {
                     //if the current DayOfWeek is the date you're looking for
                     if (looperDate.DayOfWeek == dow) 
                         //remember it.
                         returnDate = looperDate;
                     //increase day
                     looperDate=looperDate.AddDays(1);
                 }
                 return returnDate;
             }
