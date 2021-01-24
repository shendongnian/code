    var terminalSections = this.Configuration.GetSection("Terminals").GetChildren();
    foreach (var item in terminalSections)
    {
        return new Terminal 
        {
               // perform type mapping here 
        }
    }
