	using System.IO;
	using System.Linq;
	…
	var directory = Directory.GetParent(TestContext.TestDir);
	directory.EnumerateFiles()
		.ToList().ForEach(f => f.Delete());
	directory.EnumerateDirectories()
		.ToList().ForEach(d => d.Delete(true));
