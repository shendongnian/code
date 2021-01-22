        class theData { public string Name { get; set; } public string Ticker { get; set; } }
    var source = new List<theData>();
    rpContent.DataSource = source;
    rpContent.DataBind();
    
