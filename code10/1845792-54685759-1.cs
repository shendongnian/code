    public Task<(bool Worked, string Result)> DelUserTemp(string UserID, int FingerIndex)
    {
    	return Task.Run(() =>
    	{
    		if (true)
    		{
    			return (true, "done");
    		}
    		else
    		{
    			return (false, "error");
    		}
    	});
    }
