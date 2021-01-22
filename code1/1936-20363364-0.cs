You can also use yield return to treat a series of function results as a list. For instance, consider a company that pays its employees every two weeks. One could retrieve a subset of payroll dates as a list using this code:
    void Main()
    {
    	var StartDate = DateTime.Parse("01/01/2013");
    	var EndDate = DateTime.Parse("06/30/2013");
    	foreach (var d in GetPayrollDates(StartDate, EndDate)) {
    		Console.WriteLine(d);
    	}
    }
    // Calculate payroll dates in the given range.
    // Assumes the first date given is a payroll date.
    IEnumerable<DateTime> GetPayrollDates(DateTime startDate, DateTime endDate, int     daysInPeriod = 14) {
    	var thisDate = startDate;
    	while (thisDate < endDate) {
    		yield return thisDate;
    		thisDate = thisDate.AddDays(daysInPeriod);
    	}
    }
