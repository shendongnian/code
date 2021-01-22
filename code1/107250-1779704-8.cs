    var ci   = ReadTable<ContinuousIntegrationSolution>("CI", 
                  (t, name) => t.Name = name);  
    var bt   = ReadTable<BugTracker >("Bug_Tracking", 
                  (t, name) => t.Name = name);  
    var sdlc = ReadTable<SDLCProcess>("SDLC", 
                  (t, name) => t.Name = name);  
