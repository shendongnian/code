        Random randNum = new Random();
        DateTime minDt = new DateTime(2000,1,1,10,0,0);
        DateTime maxDt = new DateTime(2000,1,1,17,0,0);
        List<DateTime> myDates = new List<DateTime>();
        int minutesDiff = Convert.ToInt32(maxDt.Subtract(minDt).TotalMinutes);
    
        for (int i = 0; i < 100; i++)
        {
           // some random number that's no larger than minutesDiff, no smaller than 1
           int r=   randNum.Next(1, minutesDiff); 
           myDates.Add(minDt.AddMinutes(r));
        }
            
        foreach (DateTime d in myDates)
        {
          Console.WriteLine(string.Format("{0:dd-MMM-yyyy hh:mm}",d));
        }
