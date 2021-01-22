    private static string ManagementQuery(string query, string parameter, string scope = null) {
    	string result = string.Empty;
    	var searcher = string.IsNullOrEmpty(scope) ? new ManagementObjectSearcher(query) : new ManagementObjectSearcher(scope, query);
    	foreach (var os in searcher.Get()) {
    		try {
    			result = os[parameter].ToString();
    		}
    		catch {
    			//ignore
    		}
    
    		if (!string.IsNullOrEmpty(result)) {
    			break;
    		}
    	}
    
    	return result;
    }
