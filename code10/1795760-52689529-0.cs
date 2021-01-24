    public static string Send(string p_ipAddress, string p_action, string p_page, string p_body, string p_filePath)
    {
    	dynamic objHttp = System.Activator.CreateInstance(System.Type.GetTypeFromProgID("MSXML2.ServerXMLHTTP"));
    
    	objHttp.Open(p_action, sUrl, false);
    
    	if (t_fileContent.Length > 0)
    		objHttp.setRequestHeader("Content-Type", "multipart/form-data; boundary=" + t_multipart_boundary);
    	else
    	{
    		t_fileContent.Append(p_body);
    		objHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    	}
    
    	objHttp.Send(t_fileContent.ToString());
    
    	if (objHttp.Status == 200)
    		return objHttp.responseText;
    
    	return "";
    }
