      DateTime fileDate, closestDate;
      List<DateTime> theDates;
    
      fileDate = DateTime.Today;       //set to the file date
      theDates = new List<DateTime>(); //load the date list, obviously
    
      long min = Math.Abs(fileDate.Ticks - theDates[0].Ticks);
      long diff;
      foreach (DateTime date in theDates)
      {
        diff = Math.Abs(fileDate.Ticks - date.Ticks);
        if (diff < min)
        {
          min = diff;
          closestDate = date;
        }
      }
