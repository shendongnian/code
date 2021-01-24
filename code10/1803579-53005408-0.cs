    public Dictionary<string,string> BuildSettings(){
      var result = new Dictionary<string,string>();
        
      SubMethod1(result);
      SubMethod2(result);
                  
      return result;
        }
        
    public void SubMethod1(IDictionary<string,string> dictionary)
    {
    dictionary.Add("key1","value1");
    dictionary.Add("key2","value2");
    }
