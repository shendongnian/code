    private void SetState(EntityReference caseReference)
    {
        // Open the incident
    	// Create the Request Object
    	SetStateRequest state = new SetStateRequest();
    
    	// Set the Request Object's Properties
    	state.State = new OptionSetValue((int)IncidentState.Active);
    	state.Status = new OptionSetValue((int)incident_statuscode.WaitingforDetails);
    
    	// Point the Request to the case whose state is being changed
    	state.EntityMoniker = caseReference;
    
    	// Execute the Request
    	SetStateResponse stateSet = (SetStateResponse)_serviceProxy.Execute(state);  
    }
    
    
    private void CloseIncident(EntityReference caseReference)
    {
    	// Close the Incident
    
    	// Create resolution for the closing incident
    	IncidentResolution resolution = new IncidentResolution
    	{
    		Subject = "Case Closed",
    	};
    
    	resolution.IncidentId = caseReference;
    
    	// Create the request to close the incident, and set its resolution to the 
    	// resolution created above
    	CloseIncidentRequest closeRequest = new CloseIncidentRequest();
    	closeRequest.IncidentResolution = resolution;
    
    	// Set the requested new status for the closed Incident
    	closeRequest.Status = new OptionSetValue((int)incident_statuscode.ProblemSolved);
    
    	// Execute the close request
    	CloseIncidentResponse closeResponse = (CloseIncidentResponse)_serviceProxy.Execute(closeRequest);
    }
