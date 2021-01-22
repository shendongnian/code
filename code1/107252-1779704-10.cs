    var ci   = ReadTable("CI", 
                   name => new ContinuousIntegrationSolution() {Name = name});  
    var bt   = ReadTable("Bug_Tracking", 
                   name => new BugTracker() {Name = name});
    var sdlc = ReadTable("SDLC", 
                   name => new SDLCProcess() {Name = name});
