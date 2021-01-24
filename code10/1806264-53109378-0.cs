    var themes = new Dictionary<string, Func<string[], bool>
    {
         {"Employee", SetEmployeeSiteTheme },
         {"Government", SetGovermentSiteTheme} 
    }
     if(themes.ContainsKey("Employee"))
         themes[key].Invoke("Some markup?");
