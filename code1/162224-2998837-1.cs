            public static void Main()
            {
                XElement xDoc = XElement.Parse(
                @"<E2ETraceEvent xmlns=""http://schemas.microsoft.com/2004/06/E2ETraceEvent""> 
        <System xmlns=""http://schemas.microsoft.com/2004/06/windows/eventlog/system""> 
            <EventID>589828</EventID> 
            <Type>3</Type> 
            <SubType Name=""Information"">0</SubType> 
            <Level>8</Level> 
            <TimeCreated SystemTime=""2010-06-01T09:45:15.8102117Z"" /> 
            <Source Name=""System.ServiceModel"" /> 
            <Correlation ActivityID=""{00000000-0000-0000-0000-000000000000}"" /> 
            <Execution ProcessName=""w3wp"" ProcessID=""5012"" ThreadID=""5"" /> 
            <Channel /> 
            <Computer>TESTSERVER3A</Computer> 
        </System> 
        <ApplicationData> 
            <TraceData> 
                <DataItem> 
                    <TraceRecord xmlns=""http://schemas.microsoft.com/2004/10/E2ETraceEvent/TraceRecord"" Severity=""Information""> 
                        <TraceIdentifier>http://msdn.microsoft.com/en-GB/library/System.ServiceModel.Activation.WebHostCompilation.aspx</TraceIdentifier> 
                        <Description>Webhost compilation</Description> 
                        <AppDomain>/LM/W3SVC/257188508/Root-1-129198591101343437</AppDomain> 
                        <Source>System.ServiceModel.Activation.ServiceParser/39498779</Source> 
                        <ExtendedData xmlns=""http://schemas.microsoft.com/2006/08/ServiceModel/StringTraceRecord""> 
                            <VirtualPath>/Service.svc</VirtualPath> 
                        </ExtendedData> 
                    </TraceRecord> 
                </DataItem> 
            </TraceData> 
        </ApplicationData> 
    </E2ETraceEvent>");
    
                XNamespace nsSys = "http://schemas.microsoft.com/2004/06/windows/eventlog/system";
                XElement xEl2 = xDoc.Element(nsSys + "System");
                XElement xEl3 = xEl2.Element(nsSys + "Correlation");
                XAttribute xAtt1 = xEl3.Attribute("ActivityID");
                String sValue = xAtt1.Value;
    
                Console.WriteLine("sValue = {0}", sValue);
    
                Console.ReadKey();
            }
