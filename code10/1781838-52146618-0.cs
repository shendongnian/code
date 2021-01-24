    //note: renamed dbContext variable
    private List<Things> GetMatchingThings(DataContext doNotUseContext, string number, 
                                       DateTime startDate, DateTime endDate, 
                                       string otherNumber, string orderNumber, 
                                       string shiftNumber, 
                                       bool includeDeletedThings)
    {
        using (DataContext context = new DataContext())
        {
            //your original code here
        }
    }
    
