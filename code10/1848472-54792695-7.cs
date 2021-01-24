    // Must escape all quotes !
    string xmlSample = @"
    <properties>
        <property key=""EventId"">
            <structure type = """">
                <property key=""Id"">404</property>
            </structure>
        </property>
    	<property key=""ActionId""> 0592d9e8 - f4fd - 459f - 96b3 - 2b787d01a754</property>
    	<property key=""ActionName""> API.Controllers.CompletionsController.GetCompletion(PS.API)</property>
    	<property key=""RequestId""> 0HLJ2IL5A9: 00000001</property>
    	<property key=""RequestPath"">/api/completions/0</property>
    	<property key=""CorrelationId"" />
    	<property key=""ConnectionId"">0HLJ2IL59</property>
    	<property key=""MachineName"">RD0003FF1</property>
    	<property key=""ThreadId"">117</property>
    </properties>";
    
    StringReader reader = new StringReader(xmlSample);
    XDocument xdoc = XDocument.Parse(xmlSample);
    
    LogProperties log = new LogProperties();
    foreach (XElement prop in xdoc.Root.Elements())
    {
    	switch (prop.Attribute("key").Value)
    	{
    	case "ActionId" : log.ActionId = prop.Value; break;
    	case "ActionName" : log.ActionName = prop.Value; break;
    	
    	// and so on
    
    	}
    }
