    private static Dictionary <Type, List <PropertyInfo>> Props = new Dictionary<Type, List<PropertyInfo>> (); 
    public Dictionary <string,IList<String>> Convert(List <object> records) {                                  
        var result = new Dictionary <string,IList <string>>();                                                 
        foreach(object record in records) {                                                                    
            if (!Props.ContainsKey(record.GetType()))                                                          
                Props.Add(record.GetType(), record.GetType().GetProperties());                                 
                                                                                                               
            foreach(var prop in Props[record.GetType()]) {                                                     
                var colValue = prop.GetValue(record, null);                                                    
                if (colValue != null) {                                                                        
                    if (result.ContainsKey(prop.Name)) {                                                       
                        result[prop.Name].Add(colValue.ToString());                                            
                    }                                                                                          
                    else {                                                                                     
                        result.Add(prop.Name, new List <string> () {colValue.ToString()});                     
                    }                                                                                          
                }                                                                                              
            }                                                                                                  
        }                                                                                                      
        return result;                                                                                         
    }                
