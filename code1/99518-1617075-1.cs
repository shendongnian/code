    var currentDate = new DateTime(2009, 1, 1);
    var allDates = new List<DateTime>();
    do
    {
        allDates.Add(currentDate);
        currentDate = currentDate.AddDays(1);
    } while (currentDate < DateTime.Now);
    
    var countOfWorkDays = allDates
         .Where(day => day.IsWorkingDay())
         .Count() ;
 
