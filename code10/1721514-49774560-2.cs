    private static WorkItemAtrr UpdateWorkItemRest()
    {
	    Dictionary<string, string> _fields = new Dictionary<string, string>();  
	
	    _fields.Add("REFERENCE_NAME", "VALUE");
	
	    var _updatedWi = UpdateWorkItem("ID", _fields).Result;
    }
