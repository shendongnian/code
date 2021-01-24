    public DateTime Dob
    {
    	get
    	{
    		return _Dob;
    	}
    	set
    	{
    		if (GetAge(value) < 16)
    		{
    			Console.WriteLine("You ain't 16!");
    		}
    		else
    		{
    			_Dob = value;
    		}
    	}
    }
    
    private int GetAge(DateTime dob)
    {
    	DateTime today = DateTime.Today;
    	int age = today.Year - dob.Year;
    	if (dob > today.AddYears(-age))
    		age--;
    
       return age;
    }
