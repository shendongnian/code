    class App
    {
    	static readonly DateTime _startDate, _endDate;
    	
    	static DateTime StartDate => _startDate;
    	static DateTime EndDate => _endDate;
    	
    	static App()
    	{
    		// this code is put here implicitly by .NET
    		
    		_startDate = default;
    		_endDate = default;
    		
    		// and this code is put here by C#,
    		// translated from your initializers,
            // in the order they were declared.
    		
    		_startDate = new DateTime(_endDate.Year, 1, 1);
    		_endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
    	}
    }
