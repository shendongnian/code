    string binPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin"); // note: don't use CurrentEntryAssembly or anything like that.
    
    foreach (string dll in Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories))
    {
	try
	{                    
	    Assembly loadedAssembly = Assembly.LoadFile(dll);
	}
	catch (FileLoadException loadEx)
	{ } // The Assembly has already been loaded.
	catch (BadImageFormatException imgEx)
	{ } // If a BadImageFormatException exception is thrown, the file is not an assembly.
    } // foreach dll
}
`
