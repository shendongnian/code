    using System.IO;
    ...
	string[] extensions = { "*.apa", "*.dip", "*.ep" }; // whatever extensions you care about
	foreach (string ext in extensions)
	{
		 foreach (string file in Directory.GetFiles(@"c:\", ext, SearchOption.AllDirectories))
		 {
			  File.SetAttributes(file, FileAttributes.Normal);
			  File.Delete(file);
		 }
	}
