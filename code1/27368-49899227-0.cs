    try
    {
    	_assembly = Assembly.GetExecutingAssembly();
    	_textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("*Namespace*.*FileName*.txt"));
    }
    catch
    {
    	Console.WritelLine("Error accessing resource!");
    }
