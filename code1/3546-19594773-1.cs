    var listOfNames = new List<string>(){"John","Steve","Anna","Chris"};
    var listCount = listOfNames.Count;
    
    var NamesWithCommas = string.Empty;
    
    foreach (var element in listOfNames)
    {
        	NamesWithCommas += element;
        	if(listOfNames.IndexOf(element) != listCount -1)
	        {
                	NamesWithCommas += ", ";
	        }
    }
    
    NamesWithCommas.Dump();  //Linq Pad method to write to console.
