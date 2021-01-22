    public string GetXML(Type elementType, IEnumerable<object> listdata) {  
        foreach(object obj in listdata)   
            //logic to create xml  
    }
    public string GetXML<T>(IEnumerable<T> listdata) {
        return GetXML(typeof(T),listdata.Cast<object>());
    }
