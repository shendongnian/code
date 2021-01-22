    ReadTable("CI", (id, name)
        => _dictionary1[id] = new ContinuousIntegrationSolution{Name = name});  
    ReadTable("Bug_Tracking", (id, name) 
        => _dictionary2[id] = new BugTracker { Name = name });  
    ReadTable("SDLC", (id, name) 
        => _dictionary3[id] = new SDLCProcess { Name = name });  
