    using System.Linq;
    using System.IO;
    
    var allLines = File
        .ReadAllLines(filepath)
    	.SelectMany(x => x.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries))
    	.ToList();
