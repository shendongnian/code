    <%@ Application Language="C#" %>
    <script RunAt="server">
    	void Session_End(object sender, EventArgs e) {
    		// Code that runs when a session ends. 
    		// Note: The Session_End event is raised only when the sessionstate mode
    		// is set to InProc in the Web.config file. If session mode is set to StateServer 
    		// or SQLServer, the event is not raised.
    		
    		// remove files that has been uploaded, but not actively 'saved' or 'canceled' by the user
    		foreach (string key in Session.Keys) {
    			if (key.StartsWith("temporaryFile", StringComparison.OrdinalIgnoreCase)) {
    				try {
    					string fileName = (string)Session[key];
    					Session[key] = string.Empty;
    					if ((fileName.Length > 0) && (System.IO.File.Exists(fileName))) {
    						System.IO.File.Delete(fileName);
    					}
    				} catch (Exception) { }
    			}
    		}
    
    	}       
    </script>
