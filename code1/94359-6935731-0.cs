    public string CreateJob(string siteNumber, string customer, string jobType, string description, string reference, string externalDoc, string enteredBy, DateTime enteredDateTime)
        {
            //recordtype = 0 for job
            //load assignments and phases set to false
            return Create(0, siteNumber, customer, jobType, description, reference, externalDoc, enteredBy, enteredDateTime, false, false);
        }
    public string Create(int recordType, string siteNumber, string customer, string jobType, string description, string reference, string externalDoc, string enteredBy, DateTime enteredDateTime, bool loadAssignments, bool loadPhases)
    {
        _vmdh.Fields.FieldByName("WDDOCTYPE").SetValue(recordType, false);
        _vmdh.Fields.FieldByName("NMDOCID").SetValue(-1, false);
        _vmdh.Init();			
			....
			...
			// And it keeps going
		}
		
