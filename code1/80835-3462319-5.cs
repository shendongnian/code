	using System.IO;
	using System.Linq;
	…
	var directory = Directory.GetParent(TestContext.TestDir);
	directory.EnumerateFiles()
		.ForEachInEnumerable(f => f.Delete());
	directory.EnumerateDirectories()
		.ForEachInEnumerable(d => d.Delete(true));
