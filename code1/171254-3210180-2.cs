      public string FirstName {return m_Dynamic.FirstName ; }
      public string LastName {return m_Dynamic.LastName; }
    
      public ExpandoObject DynamicObject {get{return m_Dynamic;}}
    }
    
    // In the data mapping layer
    ViewModel vm = new ViewModel();
    Dictionary<string,string> data = new Dictionary<string,string>{{"FirstName", "Igor"}, {"LastName", "Zevaka"}};
    foreach(var kv in data) {
      ((IDictionary<string,object>)vm.DynamicObject)[kv.Key] = kv.Value;
    }
