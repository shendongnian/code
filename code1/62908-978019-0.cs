    DateTime dt = DateTime.Today;
    DateTime less5dt = dt.AddDays(-5);
    
    PrincipalSearchResult results = UserPrincipal.FindByLockoutTime(
    	adPrincipalContext,
    	dt,
    	MatchType.GreaterThanOrEquals);
    
    if (results.Count > 0)
    {
    	This.cmb1.Items.Clear();
    	foreach (Principal result in results)
    	{
    		cmb1.Items.Add(result.name);
    	}	
    }
    else
    {
    	//Considering you have a label called lblMessage
    	lblMessage.Text = "no users have been found at this time"
    	cmb1.Visible = false;
    }
