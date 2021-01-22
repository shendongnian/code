    Dictionary<Type, List<object>> numTypes = new Dictionary<Type, List<object>>();
    
    foreach(KeyValuePair<string, object> pair in _Table){
    	Type type = object.GetType();
    	if (!numTypes.ContainsKey(type)){
    		numTypes[type] = new List<object>();
         }
    
    		numTypes[type].Add(object);
    }
