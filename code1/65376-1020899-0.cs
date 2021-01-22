    while (bytesRead > 0)
    {
    	var nlenum = nle.Process(inputData, bytesRead);
    	using (var enumerator = nlenum.GetEnumerator())
    	{
    		while (enumerator.MoveNext())
    		{
    			DoSomething(enumerator);
    			Console.WriteLine(enumerator.Current);
    		}
    	}
        // ensure that bytesRead is decremented by the code that runs above
    }
    
    void DoSomething(IEnumerator<string> myenum)
    {
    	while (myenum.MoveNext())
    	{
    	    if (ShouldProcess(myenum.Current))
    	    {
    	        // process it
    	    }
    	    else
    	    {
                // return to outer loop
    	        break;
    	    }
    	}
    }
