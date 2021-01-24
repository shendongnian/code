	Assembly assembly = this.GetType().Assembly;
	string assemblyLocation = System.IO.Path.GetDirectoryName(assembly.Location);
	if (!System.IO.File.Exists(System.IO.Path.Combine(assemblyLocation, "libmp3lame.64.dll")))
	{
		using (FileStream fileStream = new FileStream(assemblyLocation + "libmp3lame.64.dll", FileMode.CreateNew, FileAccess.Write, FileShare.None))
			assembly.GetManifestResourceStream("Client.libmp3lame.64.dll").CopyTo(fileStream);
	}
