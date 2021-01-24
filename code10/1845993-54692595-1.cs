    var cookieName = 
    Configuration.GetSection("SundrySettings:CookieName").Value;
    var accessGroup = Configuration.GetSection("SundrySettings:AccessGroup").Value;
    var terminals = new List<Terminal>()
    var terminalSections = this.Configuration.GetSection("Terminals").GetChildren();
    foreach (var item in terminalSections)
    {
        terminals.Add(new Terminal 
        {
               // perform type mapping here 
        });
    }
    SundryOptions sundryOption = new SundryOptions()
    {
            CookieName = cookieName,
            HRAccessGroup = accessGroup,
            Terminals = terminalList
    };
