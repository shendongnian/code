    public void Process(ITelemetry item)
        {
            var request = item as RequestTelemetry;
            //read the flag here and terminate processing
    		if(req.Properties["MyActionFilter"] == "somthing")
    		{
    		...
    		}
        }
