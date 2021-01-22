    /*
     * Here's the short+sweet about how I'm doing this
     * 1) Copy the file from mobile device to web server by querying PHP script with paramaters for each line
     * 2) PHP script checks 1) If we got the whole data file 2) If this is a duplicate data file
     * 3) If it is a duplicate, or we didn't get the whole thing, it goes away. The mobile 
     *    device will hang on to it's data file in the first case (if it's duplicate it deletes it)
     *    to be tried again later
     * 4) The server will then process the data files using a scheduled task/cron job at an appropriate time
     */
    private void process_attempts()
    {	
    
    	Uri CheckUrl = new Uri("http://path/to/php/script?action=check");
    	WebRequest checkReq = WebRequest.Create(CheckUrl);
    	try
    	{
    		WebResponse CheckResp = checkReq.GetResponse();
    		CheckResp.Close();
    	}
    	catch
    	{
    		MessageBox.Show("Error! Connection not available. Please make sure you are online.");
    		this.Invoke(new Close(closeme));
    	}
    	StreamReader dataReader = File.OpenText(datafile);
    	String line = null;
    	line = dataReader.ReadLine();
    	while (line != null)
    	{
    		Uri Url = new Uri("http://path/to/php/script?action=process&line=" + line);
    		WebRequest WebReq = WebRequest.Create(Url);
    		try
    		{
    		  WebResponse Resp = WebReq.GetResponse();
    		  Resp.Close();
    		}
    		catch
    		{
    			MessageBox.Show("Error! Connection not available. Please make sure you are online.");
    			this.Invoke(new Close(closeme));
    			return;
    		}
    		try
    		{
    			process_bar.Invoke(new SetInt(SetBarValue), new object[] { processed });
    		}
    		catch { }
    		process_num.Invoke(new SetString(SetNumValue), new object[] { processed + "/" + attempts });
    		processed++;
    		line = dataReader.ReadLine();
    	}
    	dataReader.Close();
    	Uri Url2 = new Uri("http://path/to/php/script?action=finalize&lines=" + attempts);
    	Boolean finalized = false;
    	WebRequest WebReq2 = WebRequest.Create(Url2);
    	try
    	{
    		WebResponse Resp = WebReq2.GetResponse();
    		Resp.Close();
    		finalized = true;
    	}
    	catch
    	{
    		MessageBox.Show("Error! Connection not available. Please make sure you are online.");
    		this.Invoke(new Close(closeme));
    		finalized = false;
    	}
    	MessageBox.Show("Done!");
    	this.Invoke(new Close(closeme));
    }
