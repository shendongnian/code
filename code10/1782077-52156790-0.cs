     List<string> oldDates = new List<string>();
     List<string> futureDates = new List<string>();
    foreach(var date in dates)
    {
        string[] splitDate = date.Split('-');
        int month = int.Parse(splitDate[0]);
        int day = int.Parse(splitDate[1]);
        if(month < DateTime.Today.Month)
           oldDates.Add(date);
        else if(month == DateTime.Today.Month)
        {
            if(day < DateTime.Today.Day)
                oldDates.Add(date);
            else
                futureDates.Add(date)(
        }
        else
            futureDates.Add(date);
         dates = futureDates.AddRange(oldDates);
    }
    
