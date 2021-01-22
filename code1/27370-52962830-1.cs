    string strResourceName = "FileName.txt";
	Assembly asm = Assembly.GetExecutingAssembly();
	using( Stream rsrcStream = asm.GetManifestResourceStream(asm.GetName().Name + ".Properties." + strResourceName))
    {
		using (StreamReader sRdr = new StreamReader(rsrcStream))
		{
			//For instance, gets it as text
        	string strTxt = sRdr.ReadToEnd();
		}
	}
