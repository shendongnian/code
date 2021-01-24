    using System;
    using System.Linq;
    using System.Collections.Generic;
    ...
	var DeliveryNumbers = new List<string>() {"VLD-002546","VIV-012345"};
	
	var Result = DeliveryNumbers.Select(f=> f.Substring(4).TrimStart('0')).ToList();
	
	Result.ForEach(f=> Console.WriteLine(f));
