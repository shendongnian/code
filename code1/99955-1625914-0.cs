    static void EnableASPNET()
    {
    	var file = "wmi.vbs";
    	using (var writer = new StreamWriter(file))
    	{
    		writer.WriteLine("Set webServiceObject = GetObject(\"IIS://localhost/W3SVC\")");
    		writer.WriteLine("webServiceObject.EnableWebServiceExtension \"ASP.NET v2.0.50727\"");
    		writer.WriteLine("webServiceObject.SetInfo");
    	}
    	var process = Process.Start("cscript", file);
    	process.WaitForExit();
    	File.Delete(file);
    }
