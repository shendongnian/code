    public static void getClosestDate()
    { 
        List<DateTime> pricesList = new List<DateTime>();
        List<DateTime> finalList = new List<DateTime>();
        DateTime referenceDate = DateTime.ParseExact("08/06/2011", "dd/MM/yyyy", null);
        DateTime selectedDate = DateTime.MaxValue;
        pricesList.Add(DateTime.ParseExact("01/03/2011", "dd/MM/yyyy", null));
        pricesList.Add(DateTime.ParseExact("05/03/2011", "dd/MM/yyyy", null));  
        pricesList.Add(DateTime.ParseExact("01/05/2011", "dd/MM/yyyy", null));
        pricesList.Add(DateTime.ParseExact("02/06/2011", "dd/MM/yyyy", null));
  
    
        for (int maxResults = 0; maxResults < 3; maxResults++)
        {
            int tempDistance = int.MaxValue;
            foreach (DateTime currentDate in pricesList)
            {
                int currenDistance = this.DateDiff(currentDate, referenceDate);
               
                if (currenDistance < tempDistance)
                {
                    tempDistance = currenDistance;
                    selectedDate = currentDate;
                }
            }
     
            finalList.Add(selectedDate);
            pricesList.Remove(selectedDate);
      
        }
        foreach (DateTime currentDate in finalList)
        {
            Response.Write(currentDate + "<br>");
        }
    }
  
    private int DateDiff(DateTime Date1, DateTime Date2)
    {      
        TimeSpan time = Date1 - Date2;       
        return Math.Abs(time.Days);
    }
}
