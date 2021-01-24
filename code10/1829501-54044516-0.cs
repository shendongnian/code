    System.Collections.Generic.HashSet<string> allFound = new HashSet<string>();
	var results = monthlyResults
      // flatten the two d array
      .SelectMany(x => x)
      // select only items we have not seen before.
      .Where(x => { 
         if (allFound.Contains(x.PropC))
           return false; 
         else { 
           allFound.Add(x.PropC); 
           return true; 
         }
       });
