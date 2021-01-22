    ReadTable("CI", name
        => _dictionary1[id] = new ContinuousIntegrationSolution{Name = name});  
    ReadTable("Bug_Tracking", name 
        => _dictionary2[id] = new BugTracker { Name = name });  
    ReadTable("SDLC", name => _dictionary3[id] = new SDLCProcess { Name = name });  
