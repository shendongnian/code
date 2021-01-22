    void CreateADictionaryFromAnonymousType() 
       { 
           var dictionary = MakeDictionary(new {Name="Roy",Country="Israel"}); 
           Console.WriteLine(dictionary["Name"]); 
       }
    private IDictionary MakeDictionary(object withProperties) 
       { 
           IDictionary dic = new Dictionary<string, object>(); 
           var properties = System.ComponentModel.TypeDescriptor.GetProperties(withProperties); 
           foreach (PropertyDescriptor property in properties) 
           { 
               dic.Add(property.Name,property.GetValue(withProperties)); 
           } 
           return dic; 
       }
