    public static void SpawnIEWithSource(String szHtml)
    {
    	// Get the class type and instantiate Internet Explorer.
    	Type ieType = Type.GetTypeFromProgID("InternetExplorer.Application");
    	object ie = Activator.CreateInstance(ieType);
   
    	//Navigate to the blank page in order to make sure the Document exists
    	//ie.Navigate2("about:blank");
    	Object[] parameters = new Object[1];
    	parameters[0] = @"about:blank";
    	ie.GetType().InvokeMember("Navigate2", BindingFlags.InvokeMethod | BindingFlags.IgnoreCase, null, ie, parameters);
    	//Get the Document object now that it exists
    	//Object document = ie.Document;
    	object document = ie.GetType().InvokeMember("Document", BindingFlags.GetProperty | BindingFlags.IgnoreCase, null, ie, null);
    	//document.Write(szSourceHTML);
    	parameters = new Object[1];
    	parameters[0] = szHtml;
    	document.GetType().InvokeMember("Write", BindingFlags.InvokeMethod | BindingFlags.IgnoreCase, null, document, parameters);
    	//document.Close()
    	document.GetType().InvokeMember("Close", BindingFlags.InvokeMethod | BindingFlags.IgnoreCase, null, document, null);
    	//ie.Visible = true;
    	parameters = new Object[1];
    	parameters[0] = true;
    	ie.GetType().InvokeMember("Visible", BindingFlags.SetProperty | BindingFlags.IgnoreCase, null, ie, parameters);
    }
