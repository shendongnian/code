	using System.IO;
	using System.Linq;
	…
	var directory = Directory.GetParent(TestContext.TestDir);
	directory.GetFiles()
		.ForEachInEnumerable(f => f.Delete());
	directory.GetDirectories()
		.ForEachInEnumerable(d => d.Delete(true));
