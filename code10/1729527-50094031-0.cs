    for (int i = 0; i < objA.Length; i++) {
    	if (objA[i]?.ExecuteCode(objA[i].Any));	
    }
    
...
    void ExecuteCode(object[] children) {
    	for (int i = 0; i < children.Length; i++) {
    		if (child[i].Name.ToLower() == "code")
    		{
    			//some code
    		}
    	}
    }
