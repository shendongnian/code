    string[] Params = { "SELECT", "FROM", "WHERE", "AND", "OR", "ORDER BY"}
            Dictionary<string, string> sqlSource = new Dictionary<string, string>()
            
            //iterate through all the items from Params array
            for(i=0; i<Params.Length; i++){
    
              string result = "";
              
              //take next element from Params array for SELECT next will be FROM
              for(j=i+1; j<Params.Length; j++){
              	
              	//Get the substring between SELECT and FROM
              	if(sqlString.IndexOf(Params[j]) != null)
                 	result = sqlString.Substring(sqlString.LastIndexOf(Params[i]),sqlString.IndexOf(Params[j]))
                
                //if there is a string then break the loop 	
                if(result !=""){
                    sqlSource.Add(Params[i], result)
                	break;
                }
              }
              
              //if result is empty which is possible after FROM clause if there are no WHERE/AND/OR/ORDER BY then get substring between FROM and end of string
                if(result == ""){
                	result = sqlString.Substring(sqlString.LastIndexOf(Params[i]),sqlString.Length)
                	sqlSource.Add(Params[i], result)
                    break;
                }
            }
