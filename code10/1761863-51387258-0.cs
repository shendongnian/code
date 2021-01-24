      public List<string> CheckNames(List<string> nameList, List<string> regexList)
            {
                var missMatchNameList = new List<string>();
                foreach (var name in nameList)
                {
        		  var matched = false;
                  foreach(var regex in regexList)
                  {
                     if (Regex.IsMatch(name, regex))
                     {
                       matched=true;
                       break; 
                     }  
                  }  
        			 if (!matched)
        			 {
        				 missMatchNameList.Add(name);
        			 }  
                } 
                return missMatchNameList;
    
            }
