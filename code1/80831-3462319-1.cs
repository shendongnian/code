	using System.IO;
	using System.Linq;
	…
	var directory = Directory.GetParent(TestContext.TestDir);
	directory.GetFiles()
		.ToList().ForEach(f => f.Delete());
	directory.GetDirectories()
		.ToList().ForEach(d => d.Delete(true));
