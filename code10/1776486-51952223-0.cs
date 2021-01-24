    void Main()
    {
    	var xml = @"<root>
    	<PatientLastName>Smith</PatientLastName>
    	<PatientDOB>1956-07-18</PatientDOB>
    	<PatientSSN>999999999</PatientSSN>
    	<Facility TranslateMe=""Facility"">
    	    <Facility>TheMemorialHospital</Facility>
    	</Facility>
    	<FacilityPatientID>AAA</FacilityPatientID>
    	<FacilityEncounterID>BBB</FacilityEncounterID>
    	<Interface>
    	    <Patient>
    	        <FirstName>Alex</FirstName>
    	        <MiddleInitial>Ray</MiddleInitial>
    	        <LastName>Smith</LastName>
    	        <DOB>1956-07-18</DOB>
    	        <Gender TranslateMe=""Gender"">
    	            <Gender>F</Gender>
    	        </Gender>
    	    </Patient>
    	</Interface>
    	</root>";
    	
    	var xdoc = XDocument.Parse(xml);
    	var nodes = xdoc.XPathSelectElements("//*[@TranslateMe]");
    	foreach(var node in nodes){
    		node.Attribute("TranslateMe").Remove();
    		node.Value = Translate(node.Value);
    	}
    	xdoc.Dump();
    }
    
    public static string Translate(string input){
    	// TODO: translate input
    	return "TRANSLATED_VALUE";
    }
