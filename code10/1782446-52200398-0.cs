    Dictionary<DateTime, DateTime> Plunder = new Dictionary<DateTime, DateTime>();
    int AppointLength = 60;    
    private void GetCalendar(object username, bool Shared)
    {
    	Outlook.MAPIFolder oCalendar;
    	Outlook.Application oApp = new Outlook.Application();
    	Outlook.NameSpace oNS = oApp.GetNamespace("mapi");
    	oNS.Logon(Missing.Value, Missing.Value, true, true);
    
    	if (Shared)
    	{
    		Outlook.Recipient oRecip = oNS.CreateRecipient((string)username);
    		oCalendar = oNS.GetSharedDefaultFolder(oRecip, Outlook.OlDefaultFolders.olFolderCalendar);
    	}
    	else
    	{
    		oCalendar = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
    	}
    
    	Outlook.Items oItems = oCalendar.Items;
    	oItems.IncludeRecurrences = true;
    	oItems.Sort("[Start]");
    
    	string strRestriction = "[Start] >= '" + DateTime.Today.ToString("g") + "' AND [End] <= '" + dtpEndDate.Value.ToString("g") + "'";
    
    	Outlook.Items allNew = oItems.Restrict(strRestriction);
    
    	allNew.Sort("[Start]");
    
    	foreach (Outlook.AppointmentItem appt in allNew)
    	{
    		if (Plunder.ContainsKey(appt.Start))
    		{
    			if (Plunder[appt.Start] < appt.End)
    			{
    				Plunder[appt.Start] = appt.End;
    			}
    		}
    		else
    		{
    			Plunder.Add(appt.Start, appt.End);
    		}
    	}
    }
