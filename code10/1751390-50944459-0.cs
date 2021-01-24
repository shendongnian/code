    using System.Collections.Generic;
    using System.IO;
    public static IEnumerable<Deity> Parse(string source) {
		
		var deities = new List<Deity>();
		
		var currentDeity = new Deity();
		var currentFieldIndex = 0;
		
		var lines = source.Split(new [] {Environment.NewLine}, StringSplitOptions.None);
		Console.WriteLine("#Lines: " + lines.Count());
		
		foreach (string line in lines) {
			 
			// empty line indicates next deity
			if (string.IsNullOrWhiteSpace(line) && currentFieldIndex > 2) {
				deities.Add(currentDeity);
				currentDeity = new Deity();
				currentFieldIndex = 0;
				continue;
			}
			
			switch(currentFieldIndex) {
			    case 0: currentDeity.Name = line; break;
				case 1: currentDeity.Origin = line.Replace("Origin:", string.Empty); break;
				case 2: currentDeity.Description = line; break;
				default: break;
			}
			currentFieldIndex++;
        }
		
		return deities;
	}
