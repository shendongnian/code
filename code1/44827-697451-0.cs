    void Application_OnEndRequest(object sender, EventArgs e) {
    	int visits;
    	if (int.TryParse(Application["visits"], out visits)) {
    		visits++;
    	} else {
    		visits = 1;
    	}
    	Application["visits"] = visits;	
    }
